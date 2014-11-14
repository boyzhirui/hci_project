namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_data_01 : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.degree_levels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        degree_level_desc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                        phone = c.String(maxLength: 50),
                        addr = c.String(),
                        degree_level_id = c.Int(),
                        schedule_id = c.Int(nullable: false),
                        photo = c.Binary(storeType: "image"),
                        major_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.majors", t => t.major_id)
                .ForeignKey("dbo.schedules", t => t.schedule_id)
                .ForeignKey("dbo.degree_levels", t => t.degree_level_id)
                .Index(t => t.degree_level_id)
                .Index(t => t.schedule_id)
                .Index(t => t.major_id);
            
            CreateTable(
                "dbo.group_memberships",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        group_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.groups", t => t.group_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.group_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.groups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                        owner_id = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 1000, unicode: false),
                        course_no = c.String(maxLength: 50, unicode: false),
                        is_closed = c.Int(nullable: false),
                        max_member_number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.owner_id)
                .Index(t => t.owner_id);
            
            CreateTable(
                "dbo.meetings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50, unicode: false),
                        group_id = c.Int(nullable: false),
                        start_date = c.DateTime(nullable: false, storeType: "date"),
                        end_date = c.DateTime(nullable: false, storeType: "date"),
                        interval_type = c.String(nullable: false, maxLength: 50, unicode: false),
                        occur_day = c.String(nullable: false, maxLength: 500, unicode: false),
                        start_time = c.Time(nullable: false, precision: 7),
                        end_time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.groups", t => t.group_id)
                .Index(t => t.group_id);
            
            CreateTable(
                "dbo.meeting_attenders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        meeting_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.meetings", t => t.meeting_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.meeting_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.rel_groups_studyfields",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        group_id = c.Int(nullable: false),
                        study_field_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.study_fields", t => t.study_field_id)
                .ForeignKey("dbo.groups", t => t.group_id)
                .Index(t => t.group_id)
                .Index(t => t.study_field_id);
            
            CreateTable(
                "dbo.study_fields",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.requests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false, maxLength: 50, unicode: false),
                        sender_id = c.Int(nullable: false),
                        group_id = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.groups", t => t.group_id)
                .ForeignKey("dbo.users", t => t.sender_id)
                .Index(t => t.sender_id)
                .Index(t => t.group_id);
            
            CreateTable(
                "dbo.majors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        major_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50, unicode: false),
                        schedule_id = c.Int(nullable: false),
                        start_date = c.DateTime(nullable: false, storeType: "date"),
                        end_date = c.DateTime(nullable: false, storeType: "date"),
                        interval_type = c.String(nullable: false, maxLength: 50, unicode: false),
                        occur_day = c.String(nullable: false, maxLength: 500, unicode: false),
                        start_time = c.Time(nullable: false, precision: 7),
                        end_time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.schedules", t => t.schedule_id)
                .Index(t => t.schedule_id);*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "degree_level_id", "dbo.degree_levels");
            DropForeignKey("dbo.users", "schedule_id", "dbo.schedules");
            DropForeignKey("dbo.events", "schedule_id", "dbo.schedules");
            DropForeignKey("dbo.requests", "sender_id", "dbo.users");
            DropForeignKey("dbo.meeting_attenders", "user_id", "dbo.users");
            DropForeignKey("dbo.users", "major_id", "dbo.majors");
            DropForeignKey("dbo.groups", "owner_id", "dbo.users");
            DropForeignKey("dbo.group_memberships", "user_id", "dbo.users");
            DropForeignKey("dbo.requests", "group_id", "dbo.groups");
            DropForeignKey("dbo.rel_groups_studyfields", "group_id", "dbo.groups");
            DropForeignKey("dbo.rel_groups_studyfields", "study_field_id", "dbo.study_fields");
            DropForeignKey("dbo.meetings", "group_id", "dbo.groups");
            DropForeignKey("dbo.meeting_attenders", "meeting_id", "dbo.meetings");
            DropForeignKey("dbo.group_memberships", "group_id", "dbo.groups");
            DropIndex("dbo.events", new[] { "schedule_id" });
            DropIndex("dbo.requests", new[] { "group_id" });
            DropIndex("dbo.requests", new[] { "sender_id" });
            DropIndex("dbo.rel_groups_studyfields", new[] { "study_field_id" });
            DropIndex("dbo.rel_groups_studyfields", new[] { "group_id" });
            DropIndex("dbo.meeting_attenders", new[] { "user_id" });
            DropIndex("dbo.meeting_attenders", new[] { "meeting_id" });
            DropIndex("dbo.meetings", new[] { "group_id" });
            DropIndex("dbo.groups", new[] { "owner_id" });
            DropIndex("dbo.group_memberships", new[] { "user_id" });
            DropIndex("dbo.group_memberships", new[] { "group_id" });
            DropIndex("dbo.users", new[] { "major_id" });
            DropIndex("dbo.users", new[] { "schedule_id" });
            DropIndex("dbo.users", new[] { "degree_level_id" });
            DropTable("dbo.events");
            DropTable("dbo.schedules");
            DropTable("dbo.majors");
            DropTable("dbo.requests");
            DropTable("dbo.study_fields");
            DropTable("dbo.rel_groups_studyfields");
            DropTable("dbo.meeting_attenders");
            DropTable("dbo.meetings");
            DropTable("dbo.groups");
            DropTable("dbo.group_memberships");
            DropTable("dbo.users");
            DropTable("dbo.degree_levels");
            DropTable("dbo.AspNetUsers");
        }
    }
}
