using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.Models.DTO;
using NZWalks_API.Repository;

namespace NZWalks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IToken _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, IToken tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.userName,
                Email = registerRequestDTO.userName,
            };
            var identityResult = await _userManager.CreateAsync(identityUser,registerRequestDTO.password);

            if (identityResult.Succeeded)
            {
                //Add roles to this user
                if(registerRequestDTO.roles.Any())
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered. You can log in now.");
                }
            }
            return BadRequest("Something went wrong.");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.username);

            if (user != null)
            {
                var checkPasswordResult = await _userManager
                    .CheckPasswordAsync(user,loginRequestDTO.password);

                if (checkPasswordResult)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest("No roles assigned to access resources.");
                    }
                }
                else
                {
                    return BadRequest("Password incorrect.");
                }

            }
            return BadRequest("Username incorrect.");
        }
    }
}
