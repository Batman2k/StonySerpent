using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StonySerpent.Core.Models;
using StonySerpent.Core.Repositories;

namespace StonySerpent.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.ProductSpecification)
                .Include(p => p.ProductSpecification.ProductCategory)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            return _context
                .Products
                .Where(p =>
                    p.Name.Contains(searchTerm) ||
                    p.Brand.Contains(searchTerm) ||
                    p.SerialNumber.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm))
                .ToList();
        }

        public List<Product> GetAllProductsFromCategory(string category)
        {
            
            return _context.Products
                .Include(p => p.ProductSpecification)
                .Include(p => p.ProductSpecification.ProductCategory)
                .Where(p => p.ProductSpecification.ProductCategory.Category == category)
                .ToList();
        }

        public List<Product> GetProductsByIds(List<int> cartlist)
        {
            return _context.Products
                .Include(p => p.ProductSpecification)
                .Include(ps => ps.ProductSpecification.ProductCategory)
                .Where(p => cartlist.Contains(p.Id))
                .ToList();
        }
    }
}