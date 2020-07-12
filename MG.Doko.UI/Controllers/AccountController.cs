using MG.Doko.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AccountController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        // TODO : this login method needs to be transfered to AccountController
        [Authorize]
        public async Task<IActionResult> Login()
        {
            var client = _httpClient.CreateClient("api");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");

            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var user = client.GetAsync("users/" + _idToken.Subject).GetAwaiter().GetResult();
            var checkClaim = User.Claims.ToList();
            if (user.StatusCode == HttpStatusCode.NotFound)
            {
                var userInfo = new UserInfo();
                userInfo.EmployeeId = _idToken.Subject;
                userInfo.Username = checkClaim.Find(x => x.Type.Equals("name")).Value.ToString();
                var content = new StringContent(JsonConvert.SerializeObject(userInfo), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PostAsync("users/", content);
            }
            // TODO : redirect to user profile edit page
            return RedirectToAction("Index", "Home");
        }

        // TODO
        [HttpGet]
        public async Task<IActionResult> UpdateUserInfo()
        {
            return View();
        }

        // TODO
        [HttpPost]
        public async Task<IActionResult> UpdateUserInfo(string todo)
        {
            return View();
        }

        // TODO
        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var userClaims = User.Claims.ToList();
            var userProfile = new UserProfile
            {
                FirstName = userClaims.Find(x => x.Type.Equals("firstName")).Value.ToString(),
                LastName = userClaims.Find(x => x.Type.Equals("lastName")).Value.ToString()
            };

            return View(userProfile);
        }
    }

    //// TODO
    //[HttpPost]
    //public async Task<IActionResult> UserProfile()
    //{
    //}
}