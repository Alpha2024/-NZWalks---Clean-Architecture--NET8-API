using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomeActionFilters;
using NZWalks.API.Dtos.usersDto;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Controllers
{

    public class AuthController : BaseController
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly ITokenService _tokenservice;

        public AuthController(UserManager<IdentityUser> user, ITokenService tokenservice)
        {
            _user = user;
            _tokenservice = tokenservice;
        }

        [HttpPost]
        [Route("register_user")]
        [ValidateModel]
        public async Task<IActionResult> RegisteruserAsync([FromBody] RegisterRequestDto registerRequestDto)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityresult = await _user.CreateAsync(IdentityUser, registerRequestDto.Password);
            if (identityresult.Succeeded)
            {
                //add roles to this user
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityresult = await _user.AddToRolesAsync(IdentityUser, registerRequestDto.Roles);
                    if (identityresult.Succeeded)
                    {
                        return Ok(new { Message = "User was registered! please login" });
                    }
                }
            }
            return BadRequest("Something went wrong");
        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _user.FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var passwardresult = await _user.CheckPasswordAsync(user, loginRequestDto.Password);
                if (passwardresult)
                {
                    //Get the roles for the user
                    var roles = await _user.GetRolesAsync(user);
                    if (roles != null)
                    {
                        //create token
                        var jwtToken = _tokenservice.CreateJwtToken(user, roles.ToList());
                        var reponseToken = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(reponseToken);
                    }
                }
            }
            return BadRequest("Username or password incorrect");
        }

    }
}
