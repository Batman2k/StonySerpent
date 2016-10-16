using System.Collections.Generic;
using StonySerpent.Controllers;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Core.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAllOrdersByUserId(string userId);
        Order GetOrderByUserIdAndId(string userId, int id);

        Order CreateOrderAndUpdateAmount(string userId, OrderViewModel viewModel, List<CartProduct> cart,
            List<Product> products);

        List<Order> GetAllUnsentOrders();
        Order GetOrderById(int orderId);
    }
}