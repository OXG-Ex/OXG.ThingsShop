using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OXG.ThingsShop.Data;
using OXG.ThingsShop.Models;

namespace OXG.ThingsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> _logger, UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            logger = _logger;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var init = new DbInitializer();
            await init.InitializeAsync(userManager,roleManager);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
