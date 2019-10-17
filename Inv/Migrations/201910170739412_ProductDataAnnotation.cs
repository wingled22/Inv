namespace Inv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "QuantityPerUnit", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "QuantityPerUnit", c => c.String());
            AlterColumn("dbo.Product", "ProductName", c => c.String());
        }
    }
}
