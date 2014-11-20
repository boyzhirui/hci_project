namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_send_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.mails", "send_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.mails", "send_time");
        }
    }
}
