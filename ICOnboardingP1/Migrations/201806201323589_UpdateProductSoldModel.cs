namespace ICOnboardingP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductSoldModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSolds", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ProductSolds", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductSolds", "Store_Id", "dbo.Stores");
            DropIndex("dbo.ProductSolds", new[] { "Customer_Id" });
            DropIndex("dbo.ProductSolds", new[] { "Product_Id" });
            DropIndex("dbo.ProductSolds", new[] { "Store_Id" });
            RenameColumn(table: "dbo.ProductSolds", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.ProductSolds", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.ProductSolds", name: "Store_Id", newName: "StoreId");
            AlterColumn("dbo.ProductSolds", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSolds", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSolds", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductSolds", "CustomerId");
            CreateIndex("dbo.ProductSolds", "ProductId");
            CreateIndex("dbo.ProductSolds", "StoreId");
            AddForeignKey("dbo.ProductSolds", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductSolds", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductSolds", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSolds", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ProductSolds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductSolds", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ProductSolds", new[] { "StoreId" });
            DropIndex("dbo.ProductSolds", new[] { "ProductId" });
            DropIndex("dbo.ProductSolds", new[] { "CustomerId" });
            AlterColumn("dbo.ProductSolds", "StoreId", c => c.Int());
            AlterColumn("dbo.ProductSolds", "ProductId", c => c.Int());
            AlterColumn("dbo.ProductSolds", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.ProductSolds", name: "StoreId", newName: "Store_Id");
            RenameColumn(table: "dbo.ProductSolds", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.ProductSolds", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.ProductSolds", "Store_Id");
            CreateIndex("dbo.ProductSolds", "Product_Id");
            CreateIndex("dbo.ProductSolds", "Customer_Id");
            AddForeignKey("dbo.ProductSolds", "Store_Id", "dbo.Stores", "Id");
            AddForeignKey("dbo.ProductSolds", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.ProductSolds", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
