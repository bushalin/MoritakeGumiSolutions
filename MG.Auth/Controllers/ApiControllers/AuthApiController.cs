using MG.Auth.Data;
using MG.Auth.Models.DTOs;
using MG.Auth.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/user")]
    public class AuthApiController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthApiController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Changes the user password
        [HttpPost("{applicationUserId}")]
        public async Task<IActionResult> ChangePassword([FromRoute]string applicationUserId, [FromBody] ChangePasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(applicationUserId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.NewPassword);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(string applicationUserId, [FromBody]UpdateUserProfileDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(applicationUserId);
            //user.FirstName = userDto.FirstName;
            //user.LastName = userDto.LastName;
            //user.JobTitle = userDto.JobTitle;
            return Ok();
        }
    }
}