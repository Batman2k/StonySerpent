using System.Data.Entity;
using StonySerpent.Core.Models;

namespace StonySerpent.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductSpecification> ProductSpecifications { get; set; }
        DbSet<CustomerInformation> CustomerInformations { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrdedProduct> OrdedProducts { get; set; }
    }
}