using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace gp_.Data
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Count() == 0)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrators"));

                await roleManager.CreateAsync(new IdentityRole("patient"));
                await roleManager.CreateAsync(new IdentityRole("doctor"));
            }
            if (userManager.Users.Count() == 0)
            {
                string adminUserName = "admin@myphr.com";
                var adminUser = new IdentityUser { UserName = adminUserName, Email = adminUserName, EmailConfirmed = true };
                await userManager.CreateAsync(adminUser, "Pass@word1");
                adminUser = await userManager.FindByNameAsync(adminUserName);
                //  adminUser.EmailConfirmed = true;
                //   userManager.UpdateAsync(adminUser);
                await userManager.AddToRoleAsync(adminUser, "Administrators");
            }
        }
    }
}
