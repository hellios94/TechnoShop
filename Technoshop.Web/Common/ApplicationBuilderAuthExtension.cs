using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technoshop.Models;
using Technoshop.Web.Constants;

namespace Technoshop.Web.Common
{
    public static class ApplicationBuilderAuthExtension
    {

        private const string DefaultAdminPassword = "Admin123!";
        private const string DefaultModeratorPassword = "Moderator123!";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(WebConstants.AdminRole),
            new IdentityRole(WebConstants.ModeratorRole)
        };

        public static async void SeedDatabase(
            this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        var result = await roleManager.CreateAsync(role);
                    }
                }

                var user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new User
                    {
                        UserName = "admin",
                        Email = "admin@Technoshop.com",
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, DefaultAdminPassword);
                    result = await userManager.AddToRoleAsync(user, roles[0].Name);
                }

                var userModerator = await userManager.FindByNameAsync("moderator");
                if (userModerator == null)
                {
                    userModerator = new User
                    {
                        UserName = "moderator",
                        Email = "moderators@Technoshop.com",
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(userModerator, DefaultModeratorPassword);
                    result = await userManager.AddToRoleAsync(userModerator, roles[1].Name);
                }
            }
        }

    }
}
