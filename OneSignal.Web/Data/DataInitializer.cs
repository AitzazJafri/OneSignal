using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OneSignal.Utility.Enums;
using OneSignal.Utility.HelperClasses;
using OneSignal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneSignal.Web.Data
{
    public static class DataInitializer
    {
        public static void Seeding(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(store);
            string[] emails = { "admin@mail.com", "deo@mail.com" };
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            if (!roleManager.RoleExists(Enums.GetDescription(Roles.Admin)))
            {
                roleManager.Create(new IdentityRole(Enums.GetDescription(Roles.Admin)));
                #region Admin

                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = emails[0]
                };
                var result = userManager.Create(user, "abc123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, Enums.GetDescription(Roles.Admin));

                #endregion
            }
            if (!roleManager.RoleExists(Enums.GetDescription(Roles.Data_Entry_Operator)))
            {
                roleManager.Create(new IdentityRole(Enums.GetDescription(Roles.Data_Entry_Operator)));
                #region Data Entry Operator
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = emails[1]
                };
                var result = userManager.Create(user, "abc123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, Enums.GetDescription(Roles.Data_Entry_Operator));

                #endregion
            }


        }
    }
}