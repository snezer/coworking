using Coworking.Models;
using Microsoft.AspNetCore.Identity;

namespace Coworking.Infrastructure
{
    public static class SeedHelper
    {
        public static void SeedAthentication(UserManager<ApplicationUser>? userManager, ClaimsLoader? claimsLoader)
        {
            claimsLoader?.Load().GetAwaiter().GetResult();

            if (userManager?.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@localhost",
                    FullName = "Admin",
                    EmailConfirmed = true
                };

                IdentityResult? result = userManager?.CreateAsync(user, "Pa55w0rd#").Result;
            }
            
            var adminUser = userManager?.FindByNameAsync("admin").Result;
            if (adminUser != null && !userManager.IsInRoleAsync(adminUser, KnownRoles.Admin).Result)
            {
                IdentityResult? result = userManager.AddToRoleAsync(adminUser, KnownRoles.Admin).Result;
            }
        }
    }
}
