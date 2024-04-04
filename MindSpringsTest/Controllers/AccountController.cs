using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MindSpringsTest.Models;
using MindSpringsTest.Services.IServices;

namespace MindSpringsTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _authService.CreateUserAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            //login.ReturnUrl = returnUrl;
            return View(login);
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(Login login)
        {
            var (success, returnUrl) = await _authService.LoginAsync(login, ModelState);
            if (success)
                return RedirectToAction("Index", "String");

            return View(login);
        }


    }
}
