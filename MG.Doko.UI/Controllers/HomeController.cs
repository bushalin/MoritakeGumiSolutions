using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MG.Doko.UI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using IdentityModel.Client;

namespace MG.Doko.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        //[Authorize]
        public IActionResult Index()
        {
            return View();
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
            return RedirectToAction();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}