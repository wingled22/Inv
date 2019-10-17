namespace Inv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "CategoryName", c => c.String());
        }
    }
}
