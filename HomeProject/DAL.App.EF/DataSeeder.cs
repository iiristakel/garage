using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF
{
    public static class DataSeeder
    {
        public static void SeedInitialData(AppDbContext ctx, UserManager<AppUser> userManager)
        {
            ctx.Roles.Add(new AppRole()
            {
                Name = "Worker"
            });
            
            ctx.Roles.Add(new AppRole()
            {
                Name = "Superior"
            });
            
            
            ctx.SaveChanges();

        }
    }
}