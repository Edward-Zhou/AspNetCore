using HostInAzureWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostInAzureWebApp
{
    public class DbInitializer
    {

        public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> roleManager, ILogger<DbInitializer> logger)
        {
            //context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }
            //await CreateDefaultUserAndRoleForApplication(userManager, roleManager, logger);
            await CreateDefaultUserTableData(context, userManager, logger);
        }

        public static async Task CreateDefaultUserTableData(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            ILogger<DbInitializer> logger)
        {
            var user = await userManager.CreateAsync(new IdentityUser { UserName = "Tom", Email = "tom@outlook.com" }
            , "123@Qwe");
        }

    }
}
