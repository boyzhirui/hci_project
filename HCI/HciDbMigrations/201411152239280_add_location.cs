namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50, unicode: false),
                        address = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.meetings", "location_id", c => c.Int(nullable: false));
            CreateIndex("dbo.meetings", "location_id");
            AddForeignKey("dbo.meetings", "location_id", "dbo.locations", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.meetings", "location_id", "dbo.locations");
            DropIndex("dbo.meetings", new[] { "location_id" });
            DropColumn("dbo.meetings", "location_id");
            DropTable("dbo.locations");
        }
    }
}
