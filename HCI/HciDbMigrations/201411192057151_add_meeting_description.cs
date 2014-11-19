namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_meeting_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.meetings", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.meetings", "description");
        }
    }
}
