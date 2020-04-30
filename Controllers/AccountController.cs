using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amazon.Util.Internal.PlatformServices;
using diligent_backend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace diligent_backend.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> userManager;
        readonly SignInManager<AppUser> signInManager;
        private readonly Models.ApplicationSettings _appSettings;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<Models.ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = "admin")]
        [Route("api/account/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserApp credentials)
        {
            var user = new AppUser { FirstName = credentials.FirstName, LastName = credentials.LastName, Email = credentials.Email, UserName = credentials.Email, Role = credentials.Role };
            var result = await userManager.CreateAsync(user, credentials.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await signInManager.SignInAsync(user, isPersistent: false);
            await userManager.AddToRoleAsync(user, credentials.Role);

            var jwt = new JwtSecurityToken();
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }


        [Route("api/account/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin loginModel)
        {
            AppUser user = await userManager.FindByNameAsync(loginModel.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var role = await userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token, role });

            }
            else
            { return BadRequest(new { message = "Username or password is incorrect." }); }

        }

        [Authorize(Roles = "admin,customer")]
        [Route("api/account/users")]
        [HttpGet]
        public IQueryable<AppUser> ListAllUsers()
        {
            return this.userManager.Users;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("api/account/users/{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if(user == null)
            {
               return BadRequest(new { message = "User not found" });
            }
            else
            {
                var result = await this.userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return Ok();
                }
                return Ok();
            }
        }


    }
}