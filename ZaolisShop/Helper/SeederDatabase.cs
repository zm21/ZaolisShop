using DAL.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZaolisShop.Helper
{
    public class SeederDatabase
    {
        public static void SeedData()
        {
            var context = new ApplicationDbContext();
            SeedUsers(context);
        }
        private static void SeedUsers(ApplicationDbContext _context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            if (!roleManager.Roles.Any())
            {
                IdentityRole roleAdmin = new IdentityRole()
                {
                    Name = "Admin",
                };
                IdentityRole roleShopper = new IdentityRole()
                {
                    Name = "Shopper",
                };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleShopper);
            }
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            if (!userManager.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                userManager.Create(user, "Qwerty+1");
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}