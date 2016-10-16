using System;
using System.ComponentModel.DataAnnotations;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public int AmountInStock { get; set; }

        public ProductSpecification ProductSpecification { get; set; }

        [Required]
        public int ProductSpecificationId { get; set; }

        public void Update(Product product, ProductSpecification productSpecification)
        {
            Price = product.Price;
            Name = product.Name;
            Brand = product.Brand;
            SerialNumber = product.SerialNumber;
            Description = product.Description;
            AmountInStock = product.AmountInStock;
            productSpecification.ProductCategoryId = productSpecification.ProductCategoryId;
        }
    }
}