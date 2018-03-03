using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Persistence;
using Microsoft.AspNetCore.Identity;
using QuizApp.Model;
using QuizApp.ViewModels;
using AutoMapper;
using QuizApp.Helpers;
using System.Security.Claims;

namespace QuizApp.Controllers
{
    
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        
            private readonly AppIdDBContext _appDbContext;
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;

            public AccountsController(UserManager<AppUser> userManager, IMapper mapper, AppIdDBContext appDbContext)
            {
                _userManager = userManager;
                _mapper = mapper;
                _appDbContext = appDbContext;
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
            else {
                await _appDbContext.Interviewees.AddAsync(new Interviewee { IdentityId = userIdentity.Id, Location = model.Location, Company = model.Company });
                await _userManager.AddClaimAsync(userIdentity, new Claim(ClaimTypes.Role, "Interviewee"));
                await _appDbContext.SaveChangesAsync();

            }


            

                return new OkObjectResult("Account created");
            }
        }
}