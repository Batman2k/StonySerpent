using System.ComponentModel.DataAnnotations;

namespace StonySerpent.Core.Models
{
    public class ProductSpecification
    {
        public int Id { get; set; }

        public ProductCategory ProductCategory { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
    }
}