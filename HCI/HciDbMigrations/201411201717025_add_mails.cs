namespace HCI.HciDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        receiver_id = c.Int(nullable: false),
                        sender_id = c.Int(nullable: false),
                        mail_type = c.Int(nullable: false),
                        readed = c.Int(nullable: false),
                        subject = c.String(nullable: false, maxLength: 255),
                        content = c.String(maxLength: 4000),
                        related_id_01 = c.Int(nullable: false),
                        related_id_02 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.receiver_id)
                .ForeignKey("dbo.users", t => t.sender_id)
                .Index(t => t.receiver_id, name: "ix_mails_receiverid")
                .Index(t => t.sender_id, name: "ix_mails_senderid");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.mails", "sender_id", "dbo.users");
            DropForeignKey("dbo.mails", "receiver_id", "dbo.users");
            DropIndex("dbo.mails", "ix_mails_senderid");
            DropIndex("dbo.mails", "ix_mails_receiverid");
            DropTable("dbo.mails");
        }
    }
}
