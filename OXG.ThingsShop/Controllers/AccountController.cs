using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OXG.ThingsShop.Models;
using OXG.ThingsShop.Models.ViewModels;

namespace OXG.ThingsShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View("_RegisterPartial");
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Login };
                // добавление пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        ViewBag.Message += $"{error.Description} \n ";
                        return RedirectToAction("Index", "Home", new {message = ViewBag.Message});
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login() => View("_LoginPartial");
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            //TODO:проверка email/login
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                if (!result.Succeeded)
                {
                    ViewBag.Message = "Неправильный логин и (или) пароль";
                    return RedirectToAction("Index", "Home", new { message = ViewBag.Message });
                }
            }
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout()
        {
            // удаление аутентификационных куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}