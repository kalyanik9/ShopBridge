namespace ShopBridge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Conext_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustId", "dbo.Customer");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "CustId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.String());
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        QuntitiyOrdered = c.Int(nullable: false),
                        Cr_time_db = c.DateTime(nullable: false),
                        Ud_time_db = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        TotalPurchasedAmount = c.Double(nullable: false),
                        Cr_time_db = c.DateTime(nullable: false),
                        Ud_time_db = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        Cr_time_db = c.DateTime(nullable: false),
                        Ud_time_db = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustId);
            
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderProduct", "ProductId");
            CreateIndex("dbo.OrderProduct", "OrderId");
            CreateIndex("dbo.Order", "CustId");
            AddForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.Order", "CustId", "dbo.Customer", "CustId", cascadeDelete: true);
        }
    }
}
