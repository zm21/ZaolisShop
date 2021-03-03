namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblsshop : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogins");
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAdditionalInfoId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUserAdditionalInfo", t => t.UserAdditionalInfoId, cascadeDelete: true)
                .Index(t => t.UserAdditionalInfoId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        Order_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ProductInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Size = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProductInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductInfoId, cascadeDelete: true)
                .Index(t => t.ProductInfoId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAdditionalInfoId = c.String(nullable: false, maxLength: 128),
                        ShippingAdressId = c.Int(nullable: false),
                        DateOfOrder = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShippingAdresses", t => t.ShippingAdressId, cascadeDelete: true)
                .ForeignKey("dbo.tblUserAdditionalInfo", t => t.UserAdditionalInfoId, cascadeDelete: true)
                .Index(t => t.UserAdditionalInfoId)
                .Index(t => t.ShippingAdressId);
            
            CreateTable(
                "dbo.ShippingAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Appartment = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Phone = c.String(),
                        UserAdditionalInfoId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUserAdditionalInfo", t => t.UserAdditionalInfoId)
                .Index(t => t.UserAdditionalInfoId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Cart_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            AddColumn("dbo.tblUserAdditionalInfo", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.tblUserAdditionalInfo", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.tblUserAdditionalInfo", "FullName");
            DropColumn("dbo.tblUserAdditionalInfo", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUserAdditionalInfo", "Address", c => c.String(nullable: false));
            AddColumn("dbo.tblUserAdditionalInfo", "FullName", c => c.String(nullable: false));
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Carts", "UserAdditionalInfoId", "dbo.tblUserAdditionalInfo");
            DropForeignKey("dbo.Orders", "UserAdditionalInfoId", "dbo.tblUserAdditionalInfo");
            DropForeignKey("dbo.Orders", "ShippingAdressId", "dbo.ShippingAdresses");
            DropForeignKey("dbo.ShippingAdresses", "UserAdditionalInfoId", "dbo.tblUserAdditionalInfo");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductInfoes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "ProductInfoId", "dbo.ProductInfoes");
            DropForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Product_Id" });
            DropIndex("dbo.ShippingAdresses", new[] { "UserAdditionalInfoId" });
            DropIndex("dbo.Orders", new[] { "ShippingAdressId" });
            DropIndex("dbo.Orders", new[] { "UserAdditionalInfoId" });
            DropIndex("dbo.Images", new[] { "ProductInfoId" });
            DropIndex("dbo.ProductInfoes", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Carts", new[] { "UserAdditionalInfoId" });
            DropColumn("dbo.tblUserAdditionalInfo", "LastName");
            DropColumn("dbo.tblUserAdditionalInfo", "FirstName");
            DropTable("dbo.ProductCarts");
            DropTable("dbo.Categories");
            DropTable("dbo.ShippingAdresses");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.ProductInfoes");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            RenameTable(name: "dbo.UserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
