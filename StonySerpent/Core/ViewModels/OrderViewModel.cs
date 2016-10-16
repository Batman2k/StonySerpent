using System.Collections.Generic;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.ViewModels
{
    public class OrderViewModel
    {
        public string Title { get; set; }
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public List<CartProduct> CartProducts { get; set; }
        public List<Product> Products { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
    }
}