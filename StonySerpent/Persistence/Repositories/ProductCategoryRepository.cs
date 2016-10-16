using System.Collections.Generic;
using System.Linq;
using StonySerpent.Core.Models;
using StonySerpent.Core.Repositories;

namespace StonySerpent.Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductCategoryRepository(IApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _context.ProductCategories.ToList();
        }
    }
}