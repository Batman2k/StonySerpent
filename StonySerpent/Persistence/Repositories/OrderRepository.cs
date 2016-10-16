using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StonySerpent.Core.Models;
using StonySerpent.Core.Repositories;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContext _context;

        public OrderRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public List<Order> GetAllOrdersByUserId(string userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .ToList();
        }

        public Order GetOrderByUserIdAndId(string userId, int id)
        {
            return _context.Orders
                .Include(o => o.OrdedProducts)
                .FirstOrDefault(o => (o.UserId == userId) && (o.Id == id));
        }

        //TODO refactor
        public Order CreateOrderAndUpdateAmount(string userId, OrderViewModel viewModel, List<CartProduct> cart,
            List<Product> products)
        {
            var totalPrice = 0.0;
            var orderedProducts = new List<OrdedProduct>();

            for (var i = 0; i < cart.Count; i++)
            {
                if (products[i].Id != cart[i].ProductId)
                    return null;

                orderedProducts.Add(new OrdedProduct
                {
                    Amount = cart[i].Amount,
                    Price = products[i].Price,
                    ProductId = products[i].Id
                });
                totalPrice += orderedProducts[i].Amount*orderedProducts[i].Price;
                products[i].AmountInStock -= orderedProducts[i].Amount;
            }

            return new Order
            {
                DeliveryMethod = viewModel.DeliveryMethod,
                PaymentMethod = viewModel.PaymentMethod,
                UserId = userId,
                OrderPlaced = DateTime.Now,
                OrdedProducts = orderedProducts,
                TotalPrice = totalPrice
            };
        }

        public List<Order> GetAllUnsentOrders()
        {
            return _context.Orders
                .Where(o => o.OrderSent == null)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == orderId);
        }
    }
}