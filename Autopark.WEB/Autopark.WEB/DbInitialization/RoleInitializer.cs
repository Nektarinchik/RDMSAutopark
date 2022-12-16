using Autopark.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Autopark.WEB.DbInitialization
{
    public class RoleInitializer
    {
        public static  async Task InitializeAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string adminPassword = "admin123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole("employee"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole("customer"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "customer");
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
