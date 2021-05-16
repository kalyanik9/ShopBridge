namespace ShopBridge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_create_update_date_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Cr_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.Customer", "Ud_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.Order", "Cr_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.Order", "Ud_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.OrderProduct", "Cr_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.OrderProduct", "Ud_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.Product", "Cr_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("dbo.Product", "Ud_time_db", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Ud_time_db");
            DropColumn("dbo.Product", "Cr_time_db");
            DropColumn("dbo.OrderProduct", "Ud_time_db");
            DropColumn("dbo.OrderProduct", "Cr_time_db");
            DropColumn("dbo.Order", "Ud_time_db");
            DropColumn("dbo.Order", "Cr_time_db");
            DropColumn("dbo.Customer", "Ud_time_db");
            DropColumn("dbo.Customer", "Cr_time_db");
        }
    }
}
