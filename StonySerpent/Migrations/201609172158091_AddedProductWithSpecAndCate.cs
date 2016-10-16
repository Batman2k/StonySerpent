namespace StonySerpent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductWithSpecAndCate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Name = c.String(),
                        Brand = c.String(),
                        SerialNumber = c.String(),
                        Description = c.String(),
                        ProductSpecificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductSpecifications", t => t.ProductSpecificationId, cascadeDelete: true)
                .Index(t => t.ProductSpecificationId);
            
            CreateTable(
                "dbo.ProductSpecifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductSpecificationId", "dbo.ProductSpecifications");
            DropForeignKey("dbo.ProductSpecifications", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProductSpecifications", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "ProductSpecificationId" });
            DropTable("dbo.ProductSpecifications");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
