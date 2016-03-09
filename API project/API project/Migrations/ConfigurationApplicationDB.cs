namespace API_project.ApplicationDB.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationApplicationDB : DbMigrationsConfiguration<API_project.Models.ApplicationDbContext>
    {
        public ConfigurationApplicationDB()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(API_project.Models.ApplicationDbContext context)
        {
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new ApplicationUserManager(userStore);
            ApplicationUser admin = new ApplicationUser { UserName = "admin@gmail.com", FirstName = "Robert", LastName = "Starrett" };

            userManager.Create(admin, password: "password");
            roleManager.Create(new IdentityRole { Name = "admin" });
            userManager.AddToRole(admin.Id, "admin");
        }
    }
}
