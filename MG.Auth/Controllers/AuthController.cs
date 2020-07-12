using AutoMapper;
using MG.Auth.Data;
using MG.Auth.Data.Enums;
using MG.Auth.Data.User;
using MG.Auth.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MG.Auth.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

            if (result.Succeeded)
            {
                if (viewModel.ReturnUrl != null)
                {
                    return Redirect(viewModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.IsITAdmin = true;
            viewModel.FirstName = "alice";
            viewModel.LastName = "vegan";
            viewModel.JobTitle = "Some important Job";
            viewModel.Gender = Gender.Female;
            viewModel.BloodType = BloodType.APositive;
            viewModel.RestType = RestType.RestTypeOne;
            viewModel.Address = "japan";
            viewModel.PostNo = "8820052";
            viewModel.DateOfBirth = DateTime.Now;
            viewModel.DepartmentId = 1;
            viewModel.JobPositionId = 1;

            // mapping user information
            var userInfo = _mapper.Map<UserInfo>(viewModel);

            // Creating the new user
            var user = new ApplicationUser
            {
                UserName = viewModel.Username,
                IsITAdmin = viewModel.IsITAdmin,
                UserInfo = userInfo,
                UserInfoId = userInfo.Id
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);
            _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("test_claim", "test_user_claim")).GetAwaiter().GetResult();

            // if the user creating succeeds, login
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                if (viewModel.ReturnUrl != null)
                {
                    return Redirect(viewModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}