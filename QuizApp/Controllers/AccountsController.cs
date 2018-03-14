using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Helpers;
using QuizApp.Model;
using QuizApp.Persistence;
using QuizApp.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly AppIdDBContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        private readonly IConfiguration _config;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, AppIdDBContext appDbContext, SignInManager<AppUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _config = config;
        }

        // POST api/accounts
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            if (model.Role == "AppAdmin")
            {
                await _appDbContext.AppAdmins.AddAsync(new AppAdmin { IdentityId = userIdentity.Id, Location = model.Location, Company = model.Company, AddedDate= System.DateTime.Now, AddedById= userIdentity.Id });
                await _userManager.AddClaimAsync(userIdentity, new Claim(ClaimTypes.Role, "Administrator"));
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                await _appDbContext.Interviewees.AddAsync(new Interviewee { IdentityId = userIdentity.Id, Location = model.Location, Company = model.Company });
                await _userManager.AddClaimAsync(userIdentity, new Claim(ClaimTypes.Role, "Interviewee"));
                await _appDbContext.SaveChangesAsync();
            }

            return new OkObjectResult("Account created");
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {

            }


            return new OkObjectResult("Login Successful");
        }
        [HttpPost("Token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)


                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Tokens:Issuer"],
                    _config["Tokens:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                    );

                var Results = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return Created("", Results);

            }



            return BadRequest();

        }

    }
}