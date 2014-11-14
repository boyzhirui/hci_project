namespace HCI.Migrations
{
    using HCI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HCI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HCI.Models.ApplicationDbContext";
        }

        protected override void Seed(HCI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Users.Any(x=> x.UserName == "test01@ncsu.edu"))
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                manager.Create(new ApplicationUser { UserName = "test01@ncsu.edu", Email = "test01@ncsu.edu" }, "password");
            }
        }
    }
}
