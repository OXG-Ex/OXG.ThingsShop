using Microsoft.AspNetCore.Identity;
using OXG.ThingsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.ThingsShop.Data
{
    public class DbInitializer
    {
        public async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            //TODO: comment this
            string adminEmail = "admin@admin.com";
            string adminName = "Administrator";
            string password = "Admin_123";

            if (await roleManager.FindByNameAsync("Администратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Администратор"));
            }

            if (await roleManager.FindByNameAsync("Редактирование") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Редактирование"));
            }

            if (await roleManager.FindByNameAsync("Создание") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Создание"));
            }

            if (await roleManager.FindByNameAsync("Удаление") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Удаление"));
            }

            if (await roleManager.FindByNameAsync("Просмотр") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Просмотр"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Администратор");
                }
            }
        }
    }
}
