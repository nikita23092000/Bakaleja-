namespace Bakaleja__Курсовой_прект_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TovaryCheck : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Schedules", "Service_Id", "dbo.Services");
            DropIndex("dbo.Schedules", new[] { "Client_Id" });
            DropIndex("dbo.Schedules", new[] { "Service_Id" });
            AddColumn("dbo.Clients", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "User_Id", c => c.Int());
            CreateIndex("dbo.Clients", "User_Id");
            AddForeignKey("dbo.Clients", "User_Id", "dbo.Users", "Id");
            DropTable("dbo.Schedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOfStart = c.DateTime(nullable: false),
                        TimeOfEnd = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Clients", "User_Id", "dbo.Users");
            DropIndex("dbo.Clients", new[] { "User_Id" });
            DropColumn("dbo.Clients", "User_Id");
            DropColumn("dbo.Clients", "IsDelete");
            CreateIndex("dbo.Schedules", "Service_Id");
            CreateIndex("dbo.Schedules", "Client_Id");
            AddForeignKey("dbo.Schedules", "Service_Id", "dbo.Services", "Id");
            AddForeignKey("dbo.Schedules", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
