using System.Collections.Generic;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> SearchProducts(string searchTerm);
        List<Product> GetAllProductsFromCategory(string category);
        List<Product> GetProductsByIds(List<int> cartlist);
    }
}