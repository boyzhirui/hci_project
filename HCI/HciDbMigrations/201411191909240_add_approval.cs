namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_approval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.group_memberships", "approval", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.group_memberships", "approval");
        }
    }
}
