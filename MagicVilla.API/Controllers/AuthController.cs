using MagicVilla.API.Models.DTOs;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MagicVilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
            //this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("createuser")]

        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = createUserDto.Username,
                Email = createUserDto.Email,

            };
            var identityResult = await userManager.CreateAsync(identityUser,createUserDto.Password);
            if (identityResult.Succeeded)
            {
                if(createUserDto.Roles!=null && createUserDto.Roles.Any()) {

                    identityResult = await userManager.AddToRolesAsync(identityUser, createUserDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User registred successfuly");
                    }
                
                }
            }
            return BadRequest("Something went wrong");
        }
    }
}
