using System.Collections.Generic;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.Repositories
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetProductCategories();
    }
}