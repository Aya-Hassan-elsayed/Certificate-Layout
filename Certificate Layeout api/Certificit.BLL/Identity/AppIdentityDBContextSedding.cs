using Certificit.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Identity
{
    public class AppIdentityDBContextSedding
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var SuperAdmin = new AppUser()
                {
                    DisplayName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "11111111111"
                };
                
                var Admin = new AppUser()
                {
                    DisplayName = "Admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    PhoneNumber = "22222222222"
                };

                var SuperAdminResult = await userManager.CreateAsync(SuperAdmin, "P@$$w0rd");
                if (SuperAdminResult.Succeeded)
                {
                    await CreateRoleIfNotExists(roleManager, "SuperAdmin");
                    await userManager.AddToRoleAsync(SuperAdmin, "SuperAdmin");
                }

                var AdminResult = await userManager.CreateAsync(Admin, "P@$$w0rd");
                if (AdminResult.Succeeded)
                {
                    await CreateRoleIfNotExists(roleManager, "Admin");
                    await userManager.AddToRoleAsync(Admin, "Admin");
                }
                await CreateRoleIfNotExists(roleManager, "New");
                await CreateRoleIfNotExists(roleManager, "Edit");
                await CreateRoleIfNotExists(roleManager, "Preview");

            }
        }

        private static async Task CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }
    }
}
