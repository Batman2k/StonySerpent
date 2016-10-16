using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using StonySerpent.Controllers;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        public int AmountInStock { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public string Title { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ProductsController, ActionResult>> update = c => c.Update(this);
                Expression<Func<ProductsController, ActionResult>> create = c => c.Create(this);

                var action = Id != 0 ? update : create;

                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}