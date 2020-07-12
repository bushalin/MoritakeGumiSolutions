using MG.Doko.Domain.DTOs;
using MG.Doko.Domain.DTOs.Users;
using MG.Doko.Service.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MG.Doko.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{userId}", Name = "GetUserByEmployeeId")]
        public IActionResult GetUserByEmployeeId(string userId)
        {
            var result = _userServices.GetUserByEmployeeId(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserCreateDto createDto)
        {
            var result = _userServices.CreateUser(createDto);
            if (!result.Succeeded)
            {
                throw new Exception("Cannot create User at Api: " + result.Errors.FirstOrDefault());
            }
            return CreatedAtRoute(nameof(GetUserByEmployeeId), result);
        }

        // TODO
        [HttpPost("{applicationUserId}")]
        public IActionResult UpdateUserInfo([FromRoute]string applicationUserId, [FromBody] UpdateUserInfoDto infoDto)
        {
            return NoContent();
        }
    }
}