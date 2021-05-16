namespace ShopBridge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Category_table_create_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Cr_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.ProductCategories", "Ud_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "Ud_time_db");
            DropColumn("dbo.ProductCategories", "Cr_time_db");
        }
    }
}
