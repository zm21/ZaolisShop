namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartId : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderProducts", newName: "ProductOrders");
            DropForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "Cart_Id" });
            RenameColumn(table: "dbo.CartItems", name: "Cart_Id", newName: "CartId");
            DropPrimaryKey("dbo.ProductOrders");
            AlterColumn("dbo.CartItems", "CartId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductOrders", new[] { "Product_Id", "Order_Id" });
            CreateIndex("dbo.CartItems", "CartId");
            AddForeignKey("dbo.CartItems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropPrimaryKey("dbo.ProductOrders");
            AlterColumn("dbo.CartItems", "CartId", c => c.Int());
            AddPrimaryKey("dbo.ProductOrders", new[] { "Order_Id", "Product_Id" });
            RenameColumn(table: "dbo.CartItems", name: "CartId", newName: "Cart_Id");
            CreateIndex("dbo.CartItems", "Cart_Id");
            AddForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts", "Id");
            RenameTable(name: "dbo.ProductOrders", newName: "OrderProducts");
        }
    }
}
