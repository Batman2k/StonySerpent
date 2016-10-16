using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StonySerpent.Core.Models
{
    public class Order
    {
        public Order()
        {
            OrdedProducts = new Collection<OrdedProduct>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderSent { get; set; }

        public string PaymentMethod { get; set; }

        public bool IsPaid { get; set; }

        public string DeliveryMethod { get; set; }

        public double TotalPrice { get; set; }

        public ICollection<OrdedProduct> OrdedProducts { get; set; }
    }
}