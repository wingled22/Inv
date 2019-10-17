namespace Inv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDecimalPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Price", c => c.Int(nullable: false));
        }
    }
}
