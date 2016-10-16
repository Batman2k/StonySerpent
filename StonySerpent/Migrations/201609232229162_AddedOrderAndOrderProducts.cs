namespace StonySerpent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderAndOrderProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        OrderPlaced = c.DateTime(nullable: false),
                        OrderSent = c.DateTime(),
                        PaymentMethod = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        DeliveryMethod = c.String(),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdedProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrdedProducts", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrdedProducts");
        }
    }
}
