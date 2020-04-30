using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace diligent_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        public UserProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        //[Authorize]
        public async Task<Object> GetUserProfile()
        {
            var userId = User.Claims.ToList().FirstOrDefault().Value;
            AppUser user = await _userManager.FindByIdAsync(userId);
            return new
            {
                userId,
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Role,
            };

        }

    }
}