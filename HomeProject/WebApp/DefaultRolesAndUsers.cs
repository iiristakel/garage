using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

namespace WebApp
{
    public static class DefaultRolesAndUsers
    {
        public static void AddDefaultRolesAndUsers(this IApplicationBuilder app, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (!roleManager.Roles.Any(r => r.NormalizedName == "ADMIN"))
            {
                var result = roleManager.CreateAsync(new AppRole() {Name = "Admin"}).Result;
                if (result == IdentityResult.Success)
                {
                    // ??
                }
            }
            
            if (!roleManager.Roles.Any(r => r.NormalizedName == "WORKER"))
            {
                var result = roleManager.CreateAsync(new AppRole() {Name = "Worker"}).Result;
                if (result == IdentityResult.Success)
                {
                    // ??
                }
            }

            var user = userManager.FindByEmailAsync("admin@admin.com").Result;
            if (user == null)
            {
                var result = userManager.CreateAsync(new AppUser()
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    FirstName = "admin",
                    LastName = "admin"
                }, "adminadmin").Result;
                if (result == IdentityResult.Success)
                {
                    user = userManager.FindByEmailAsync("admin@admin.com").Result;
                }
            }

            if (user != null && !userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var result = userManager.AddToRoleAsync(user, "Admin").Result;
            }
            
        }

    }
}