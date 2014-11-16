namespace HCI.HciDbMigrations
{
    using HCI.Models.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HCI.Utils;
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

            Major ceMajor = context.Majors.Where(x => x.major_name == "Computer Engineering").FirstOrDefault();
            if (ceMajor == null)
            {
                ceMajor = new Major { major_name = "Computer Engineering" };
                context.Majors.Add(ceMajor);
                context.SaveChanges();
            }

            Major mathMajor = context.Majors.Where(x => x.major_name == "Mathematics").FirstOrDefault();
            if (mathMajor == null)
            {
                mathMajor = new Major { major_name = "Mathematics" };
                context.Majors.Add(mathMajor);
                context.SaveChanges();
            }

            #endregion

            #region Study Fields
            StudyField csSF = context.StudyFields.Where(x => x.name == "Computer Science").FirstOrDefault();
            if (csSF == null)
            {
                csSF = new StudyField { name = "Computer Science" };
                context.StudyFields.Add(csSF);
                context.SaveChanges();
            }

            StudyField ceSF = context.StudyFields.Where(x => x.name == "Computer Engineering").FirstOrDefault();
            if (ceSF == null)
            {
                ceSF = new StudyField { name = "Computer Engineering" };
                context.StudyFields.Add(ceSF);
                context.SaveChanges();
            }

            StudyField mathSF = context.StudyFields.Where(x => x.name == "Mathematics").FirstOrDefault();
            if (mathSF == null)
            {
                mathSF = new StudyField { name = "Mathematics" };
                context.StudyFields.Add(mathSF);
                context.SaveChanges();
            }
            #endregion
            #region Schedule init
            Schedule defaultSchedule = context.Schedules.Where(x => x.description == "default schedule").FirstOrDefault();

            if (defaultSchedule == null)
            {
                defaultSchedule = new Schedule { description = "default schedule" };
                context.Schedules.Add(defaultSchedule);
                context.SaveChanges();
            }
            #endregion

            #region Event init
            Event event1 = context.Events.Where(x => x.name == "Class 1").FirstOrDefault();
            if (event1 == null)
            {
                event1 = new Event
                {
                    name = "Class 1",
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(9, 0, 0),
                    end_time = new TimeSpan(12, 0, 0),
                    interval_type = Consts.IntervalType.Week,
                    occur_day = string.Join(",", Consts.Days.Monday, Consts.Days.Wednesday),
                    schedule = defaultSchedule
                };
                context.Events.Add(event1);
                context.SaveChanges();
            }

            Event event2 = context.Events.Where(x => x.name == "Class 2").FirstOrDefault();
            if (event2 == null)
            {
                event2 = new Event
                {
                    name = "Class 2",
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(13, 0, 0),
                    end_time = new TimeSpan(15, 0, 0),
                    interval_type = Consts.IntervalType.Week,
                    occur_day = string.Join(",", Consts.Days.Tuesday, Consts.Days.Thursday),
                    schedule = defaultSchedule
                };
                context.Events.Add(event2);
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

            DegreeLevel gDegLev = context.DegreeLevels.Where(x => x.degree_level_desc == "Graduate").FirstOrDefault();

            if (gDegLev == null)
            {
                gDegLev = new DegreeLevel { degree_level_desc = "Graduate" };
                context.DegreeLevels.Add(gDegLev);
                context.SaveChanges();
            }
            #endregion

            #region User init

            User user1 = context.Users.Where(x => x.name == "test01").FirstOrDefault();
            if (user1 == null)
            {
                user1 = new User { name = "test01@ncsu.edu", DegreeLevel = ugDegLev, Schedule = defaultSchedule, Major = csMajor };
                context.Users.Add(user1);
                context.SaveChanges();
            }

            User user2 = context.Users.Where(x => x.name == "test02").FirstOrDefault();
            if (user2 == null)
            {
                user2 = new User { name = "test02", DegreeLevel = gDegLev, Schedule = defaultSchedule, Major = ceMajor };
                context.Users.Add(user2);
                context.SaveChanges();
            }

            User user3 = context.Users.Where(x => x.name == "test03").FirstOrDefault();
            if (user3 == null)
            {
                user3 = new User { name = "test03", DegreeLevel = gDegLev, Schedule = defaultSchedule, Major = mathMajor };
                context.Users.Add(user3);
                context.SaveChanges();
            }
            #endregion

            #region Group init
            Group grp1 = context.Groups.Where(x => x.name == "Group 1").FirstOrDefault();
            if (grp1 == null)
            {
                grp1 = new Group { name = "Group 1", course_no = "CSC 554", description = "Group 1 Description", is_closed = YesNo.No, max_member_number = 10, Owner = user1};
                context.Groups.Add(grp1);
                context.SaveChanges();
            }

            Group grp2 = context.Groups.Where(x => x.name == "Group 2").FirstOrDefault();
            if (grp2 == null)
            {
                grp2 = new Group { name = "Group 2", course_no = "CSC 520", description = "Group 2 Description", is_closed = YesNo.Yes, max_member_number = 10, Owner = user2 };
                context.Groups.Add(grp2);
                context.SaveChanges();
            }

            Group grp3 = context.Groups.Where(x => x.name == "Group 3").FirstOrDefault();
            if (grp3 == null)
            {
                grp3 = new Group { name = "Group 3", course_no = "CSC 600", description = "Group 3 Description", is_closed = YesNo.No, max_member_number = 10, Owner = user3 };
                context.Groups.Add(grp3);
                context.SaveChanges();
            }

            Group grp4 = context.Groups.Where(x => x.name == "Group 4").FirstOrDefault();
            if (grp4 == null)
            {
                grp4 = new Group { name = "Group 4", course_no = "CSC 501", description = "Group 4 Description", is_closed = YesNo.No, max_member_number = 10, Owner = user1 };
                context.Groups.Add(grp4);
                context.SaveChanges();
            }
            #endregion

            #region Group StudyFields
            context.RelGroupsStudyfields.AddOrUpdate(
                x => new { x.group_id, x.study_field_id },
                new RelGroupsStudyfield { group_id = grp1.id, study_field_id = csSF.id },
                new RelGroupsStudyfield { group_id = grp1.id, study_field_id = ceSF.id },
                new RelGroupsStudyfield { group_id = grp2.id, study_field_id = csSF.id },
                new RelGroupsStudyfield { group_id = grp2.id, study_field_id = ceSF.id },
                new RelGroupsStudyfield { group_id = grp3.id, study_field_id = mathSF.id });
            context.SaveChanges();
            #endregion
            #region GroupMembership
            context.GroupMemberships.AddOrUpdate(x => new { x.group_id, x.user_id }, 
                new GroupMembership { group_id = grp1.id, user_id = user1.id },
                new GroupMembership { group_id = grp1.id, user_id = user2.id },
                new GroupMembership { group_id = grp1.id, user_id = user3.id },
                new GroupMembership { group_id = grp2.id, user_id = user1.id },
                new GroupMembership { group_id = grp2.id, user_id = user2.id },
                new GroupMembership { group_id = grp2.id, user_id = user3.id },
                new GroupMembership { group_id = grp3.id, user_id = user1.id },
                new GroupMembership { group_id = grp3.id, user_id = user2.id },
                new GroupMembership { group_id = grp3.id, user_id = user3.id });
            #endregion

            #region Location init

            Location location1 = context.Locations.Where(x => x.name == "Room 1").FirstOrDefault();
            if (location1 == null)
            {
                location1 = new Location { name = "Room 1", address = "Room 1, Hunt Lib, North Carolina State University" };
                context.Locations.Add(location1);
                context.SaveChanges();
            }

            Location location2 = context.Locations.Where(x => x.name == "Room 2").FirstOrDefault();
            if (location2 == null)
            {
                location2 = new Location { name = "Room 2", address = "Room 2, Hunt Lib, North Carolina State University" };
                context.Locations.Add(location2);
                context.SaveChanges();
            }

            Location location3 = context.Locations.Where(x => x.name == "Room 3").FirstOrDefault();
            if (location3 == null)
            {
                location3 = new Location { name = "Room 3", address = "Room 3, Hunt Lib, North Carolina State University" };
                context.Locations.Add(location2);
                context.SaveChanges();
            }

            #endregion
            #region Meeting

            Meeting meeting1_1 = context.Meetings.Where(x => x.name == "Group 1's meeting 1").FirstOrDefault();
            if (meeting1_1 == null)
            {
                meeting1_1 = new Meeting
                {
                    name = "Group 1's meeting 1",
                    Group = grp1,
                    occur_day = Consts.Days.Friday,
                    interval_type = Consts.IntervalType.Week,
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(19, 0, 0),
                    end_time = new TimeSpan(21, 0, 0),
                    Location = location1
                };

                context.Meetings.Add(meeting1_1);
                context.SaveChanges();
            }

            Meeting meeting1_2 = context.Meetings.Where(x => x.name == "Group 1's meeting 2").FirstOrDefault();
            if (meeting1_2 == null)
            {
                meeting1_2 = new Meeting
                {
                    name = "Group 1's meeting 2",
                    Group = grp1,
                    occur_day = Consts.Days.Monday,
                    interval_type = Consts.IntervalType.Week,
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(19, 0, 0),
                    end_time = new TimeSpan(21, 0, 0),
                    Location = location2
                };

                context.Meetings.Add(meeting1_2);
                context.SaveChanges();
            }

            Meeting meeting2_1 = context.Meetings.Where(x => x.name == "Group 2's meeting 1").FirstOrDefault();
            if (meeting2_1 == null)
            {
                meeting2_1 = new Meeting
                {
                    name = "Group 2's meeting 1",
                    Group = grp2,
                    occur_day = Consts.Days.Thursday,
                    interval_type = Consts.IntervalType.Week,
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(19, 0, 0),
                    end_time = new TimeSpan(21, 0, 0),
                    Location = location3
                };

                context.Meetings.Add(meeting2_1);
                context.SaveChanges();
            }

            Meeting meeting3_1 = context.Meetings.Where(x => x.name == "Group 3's meeting 1").FirstOrDefault();
            if (meeting3_1 == null)
            {
                meeting3_1 = new Meeting
                {
                    name = "Group 3's meeting 1",
                    Group = grp3,
                    occur_day = Consts.Days.Saturday,
                    interval_type = Consts.IntervalType.Week,
                    start_date = new DateTime(2014, 1, 1),
                    end_date = new DateTime(2014, 12, 31),
                    start_time = new TimeSpan(19, 0, 0),
                    end_time = new TimeSpan(21, 0, 0),
                    Location = location1
                };

                context.Meetings.Add(meeting3_1);
                context.SaveChanges();
            }
            #endregion
           
        }
    }
}
