namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartitems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.ProductCarts", new[] { "Product_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Cart_Id" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductInfoId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.ProductInfoId)
                .Index(t => t.Cart_Id);
            
            AddColumn("dbo.Carts", "Product_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
            DropTable("dbo.ProductCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Cart_Id });
            
            DropForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "ProductInfoId", "dbo.ProductInfoes");
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "Cart_Id" });
            DropIndex("dbo.CartItems", new[] { "ProductInfoId" });
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropColumn("dbo.Carts", "Product_Id");
            DropTable("dbo.CartItems");
            CreateIndex("dbo.ProductCarts", "Cart_Id");
            CreateIndex("dbo.ProductCarts", "Product_Id");
            AddForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
