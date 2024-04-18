using MagicVilla.API.Models.DTOs;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace MagicVilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenRepository = tokenRepository;
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

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
            if(user is not null)
            {
                var checkPaswordResult = await signInManager.PasswordSignInAsync(user, loginRequestDto.Password,isPersistent:false ,lockoutOnFailure: false);
                if(checkPaswordResult.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        JwtToken = jwtToken
                    };
                    return  Ok(response);
                }
            }
            return BadRequest("Username or Password is not correct");
        }

        [HttpGet]
        [Route("getuser")]
        [Authorize]

        public async Task<IActionResult> GetUser()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized("User not found");
        }
        [HttpPut]
        [Route("updateuser")]

        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto updateUserDto)
        {
            
            {
                var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound("User not found");
                }                
                user.UserName = updateUserDto.Username;
                
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok("User updated successfully");
                }
                else
                {
                    
                    return StatusCode(500, "Failed to update user");
                }
            }
        }

        [HttpDelete]
        [Route("deleteuser")]
        [Authorize]

        public async Task<IActionResult> DeleteUser()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return Ok("User has been deleted successfuly");
            }

            return Unauthorized("User not found");



        }
        [HttpGet]
        [Authorize]
        [Route("logout")]

        public async Task<IActionResult> LogOut()
        {
             await signInManager.SignOutAsync();
            return Ok("User was logged out successfuly");
        }

    }
}
