namespace OneSignal.Web.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OneSignal.Utility.Enums;
    using OneSignal.Utility.HelperClasses;
    using OneSignal.Web.Data;
    using OneSignal.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OneSignal.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(OneSignal.Web.Models.ApplicationDbContext context)
        {
           DataInitializer.Seeding(context);
        }
    }
}
