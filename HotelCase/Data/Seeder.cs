using System;
using HotelCase.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HotelCase.Data
{
    public static class Seeder
    {
        public static void Initialize(this IApplicationBuilder app, IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // check for roles 
            var adminRole = roleManager.FindByNameAsync("Admin").Result;
            if (adminRole == null)
            {
                adminRole = new IdentityRole("Admin");
                roleManager.CreateAsync(adminRole).Wait();
            }
            var guestRole = roleManager.FindByNameAsync("Guest").Result;
            if (guestRole == null)
            {
                guestRole = new IdentityRole("Guest");
                roleManager.CreateAsync(guestRole).Wait();
            }
            var recepRole = roleManager.FindByNameAsync("Receptionist").Result;
            if (recepRole == null)
            {
                recepRole = new IdentityRole("Receptionist");
                roleManager.CreateAsync(recepRole).Wait();
            }

            var adminUser = userManager.FindByNameAsync("admin@hotelkamer.nu").Result;
            if (adminUser == null)
            {
                adminUser = new ApplicationUser() { UserName = "admin@nee.nee", Email = "admin@nee.nee" };
                var result = userManager.CreateAsync(adminUser, "aaaaaA-0").Result;
                result = userManager.SetLockoutEnabledAsync(adminUser, false).Result;

                userManager.AddToRoleAsync(adminUser, adminRole.Name).Wait();
                userManager.AddToRoleAsync(adminUser, recepRole.Name).Wait();
            }

        }
    }
}