using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SliceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SliceDelivery.DAL;
using SliceDelivery.Domain.Models;
using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Service.Interfaces;
using SliceDelivery.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SliceDelivery.Service.Interfaces;
using SliceDelivery.Domain.ViewModels.Profile;

namespace SliceDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;
        private readonly IProfileService _profileService;
        public HomeController(ILogger<HomeController> logger, IProductService productService, IAccountService accountService, IProfileService profileService)
        {
            _logger = logger;
            _productService = productService;
            _accountService = accountService;
            _profileService = profileService;
        }
        [HttpGet]
        public IActionResult IndexAsync()
        {
            var response = _productService.GetProducts();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                ViewBag.Number = 0;
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }
        /*
        public async Task<IActionResult> IndexAsync()
        {

            ViewBag.Number = 0;
            return View();
        }
        public new IActionResult User()
        {
            return View();
        }*/
        public IActionResult About()
        {
            ViewBag.Number = 1;
            return View();
        }
        /*public IActionResult Menu()
        {
            ViewBag.Number = 2;
            return View();
        }*/
        [HttpGet]
        public IActionResult Menu()
        {
            var response = _productService.GetProducts();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                ViewBag.Number = 2;
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }
        public IActionResult Products()
        {
            ViewBag.Number = 3;
            return View();
        }
        public IActionResult Review()
        {
            ViewBag.Number = 4;
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Number = 5;
            return View();
        }
        public IActionResult Blog()
        {
            ViewBag.Number = 6;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        //----------------------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ChangePassword(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            var modelError = ModelState.Values.SelectMany(v => v.Errors);

            return StatusCode(StatusCodes.Status500InternalServerError, new { modelError.FirstOrDefault().ErrorMessage });
        }
        //----------------------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> Save(ProfileViewModel model)
        {
            ModelState.Remove("Id");
            ModelState.Remove("UserName");
            if (ModelState.IsValid)
            {
                var response = await _profileService.Save(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        public async Task<IActionResult> Detail()
        {
            var userName = User.Identity.Name;
            var response = await _profileService.GetProfile(userName);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }

        //----------------------------------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
