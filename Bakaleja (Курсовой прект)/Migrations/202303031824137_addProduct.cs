namespace Bakaleja__Курсовой_прект_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Amount = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.DateTime(nullable: false),
                        Tovary_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tovaries", t => t.Tovary_Id)
                .Index(t => t.Tovary_Id);
            
            CreateTable(
                "dbo.Tovaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Tovary_Id", "dbo.Tovaries");
            DropForeignKey("dbo.Schedules", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Schedules", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Services", new[] { "Tovary_Id" });
            DropIndex("dbo.Schedules", new[] { "Service_Id" });
            DropIndex("dbo.Schedules", new[] { "Client_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tovaries");
            DropTable("dbo.Services");
            DropTable("dbo.Schedules");
            DropTable("dbo.Clients");
        }
    }
}
