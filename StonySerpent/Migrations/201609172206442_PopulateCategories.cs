using System.Data.Entity.Migrations;
using StonySerpent.Core.Models;
using StonySerpent.Persistence;

namespace StonySerpent.Migrations
{
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            var context = new ApplicationDbContext();

            context.ProductCategories.Add(new ProductCategory { Category = "Datorer" });
            context.ProductCategories.Add(new ProductCategory { Category = "Datortillbehör" });
            context.ProductCategories.Add(new ProductCategory { Category = "Nätverk" });
            context.ProductCategories.Add(new ProductCategory { Category = "Programvara" });
            context.ProductCategories.Add(new ProductCategory { Category = "Spel" });
            context.ProductCategories.Add(new ProductCategory { Category = "Övriga artiklar" });
            

            context.SaveChanges();
        }

        public override void Down()
        {
        }
    }
}