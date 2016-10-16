namespace StonySerpent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdedProductId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdedProducts", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.OrdedProducts", "SerialNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdedProducts", "SerialNumber", c => c.String());
            DropColumn("dbo.OrdedProducts", "ProductId");
        }
    }
}
