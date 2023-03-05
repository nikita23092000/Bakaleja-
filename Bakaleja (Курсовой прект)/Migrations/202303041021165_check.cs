namespace Bakaleja__Курсовой_прект_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfCreate = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Client_Id = c.Int(),
                        Service_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        type = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Clients", "Product_Id", c => c.Int());
            AddColumn("dbo.Tovaries", "User_Id", c => c.Int());
            CreateIndex("dbo.Clients", "Product_Id");
            CreateIndex("dbo.Tovaries", "User_Id");
            AddForeignKey("dbo.Tovaries", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Clients", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Clients", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Shops", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Shops", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Shops", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Tovaries", "User_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropIndex("dbo.Shops", new[] { "User_Id" });
            DropIndex("dbo.Shops", new[] { "Service_Id" });
            DropIndex("dbo.Shops", new[] { "Client_Id" });
            DropIndex("dbo.Tovaries", new[] { "User_Id" });
            DropIndex("dbo.Clients", new[] { "Product_Id" });
            DropColumn("dbo.Tovaries", "User_Id");
            DropColumn("dbo.Clients", "Product_Id");
            DropTable("dbo.Products");
            DropTable("dbo.Shops");
        }
    }
}
