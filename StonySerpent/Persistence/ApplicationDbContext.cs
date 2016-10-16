using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StonySerpent.Core.Models;

namespace StonySerpent.Persistence
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<CustomerInformation> CustomerInformations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdedProduct> OrdedProducts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}