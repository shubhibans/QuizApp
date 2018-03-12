using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Helpers;
using QuizApp.Model;
using QuizApp.Persistence;
using QuizApp.ViewModels;
using System.Security.Claims;
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

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, AppIdDBContext appDbContext, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
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
                await _appDbContext.AppAdmins.AddAsync(new AppAdmin { IdentityId = userIdentity.Id, Location = model.Location, Company = model.Company });
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

        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _signInManager.PasswordSignInAsync(model.EmailId, model.Password, false, false);
            if (result.Succeeded)
            {

            }


            return new OkObjectResult("Login Successful");
        }
    }
}