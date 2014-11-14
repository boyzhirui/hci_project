namespace HCI.HciDbMigrations
{
    using HCI.Models.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HCI.Models.Database.HciDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"HciDbMigrations";
        }

        protected override void Seed(HCI.Models.Database.HciDb context)
        {
            #region Major
            Major csMajor = context.Majors.Where(x => x.major_name == "Computer Science").FirstOrDefault();
            if (csMajor == null)
            {
                csMajor = new Major { major_name = "Computer Science" };
                context.Majors.Add(csMajor);
                context.SaveChanges();
            }

            #endregion

            #region Schedule init
            Schedule defaultSchedule = context.Schedules.Where(x => x.description == "test's schedule").FirstOrDefault();

            if (defaultSchedule == null)
            {
                defaultSchedule = new Schedule { description = "test's schedule" };
                context.Schedules.Add(defaultSchedule);
                context.SaveChanges();
            }
            #endregion

            #region DegreeLevel init
            DegreeLevel ugDegLev = context.DegreeLevels.Where(x => x.degree_level_desc == "Undergraduate").FirstOrDefault();
            
            if(ugDegLev == null)
            {
                ugDegLev = new DegreeLevel { degree_level_desc = "Undergraduate" };
                context.DegreeLevels.Add(ugDegLev);
                context.SaveChanges();
            }

            #endregion

            if (!context.Users.Any(x=> x.name == "test01@ncsu.edu"))
            {
                context.Users.Add(new User { name = "test01@ncsu.edu", DegreeLevel = ugDegLev, Schedule = defaultSchedule, Major = csMajor });
                context.SaveChanges();
            }
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
        }
    }
}
