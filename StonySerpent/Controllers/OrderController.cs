using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StonySerpent.Core;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult CustomerInfo()
        {
            var viewModel = _unitOfWork.CustomerInformations.GetInfoById(User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CustomerInfo(CustomerInformation viewModel)
        {
            if (!ModelState.IsValid)
                return View("CustomerInfo", viewModel);

            var customerInfo = _unitOfWork.CustomerInformations.GetInfoById(User.Identity.GetUserId());

            if (customerInfo == null)
                _unitOfWork.CustomerInformations.Add(viewModel.SetUserId(User.Identity.GetUserId()));

            else
                customerInfo.Update(viewModel);

            _unitOfWork.Finish();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Cart()
        {
            var cart = (List<CartProduct>) Session["cart"];

            if (cart == null)
                return HttpNotFound();

            var viewmodel = new OrderViewModel
            {
                Title = "Cart",
                CartProducts = cart
            };

            return View(viewmodel);
        }


        //TODO change to API
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Cart(CartProduct cartProduct)
        {
            var cart = (List<CartProduct>) Session["cart"];
            var productInCart = cart.FirstOrDefault(p => p.ProductId == cartProduct.ProductId);

            if (productInCart != null)
                productInCart.Amount = cartProduct.Amount;

            cart.RemoveAll(p => p.Amount == 0);

            Session["cart"] = cart;

            return RedirectToAction("Cart");
        }

        public ActionResult PlaceOrder()
        {
            var cart = (List<CartProduct>) Session["cart"];

            var viewModel = new OrderViewModel
            {
                Title = "Order",
                CartProducts = cart,
                Order = new Order {TotalPrice = cart.Select(c => c.Amount*c.Price).Sum()},
                Products = _unitOfWork.Products.GetProductsByIds(
                    cart.Select(c => c.ProductId).ToList())
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(OrderViewModel viewModel)
        {
            if (_unitOfWork.CustomerInformations.GetInfoById(User.Identity.GetUserId()) == null)
                return Redirect("CustomerInfo");

            var cart = (List<CartProduct>) Session["cart"];
            var order = _unitOfWork.Orders
                .CreateOrderAndUpdateAmount(User.Identity.GetUserId(), viewModel, cart,
                    _unitOfWork.Products.GetProductsByIds(
                        cart.Select(c => c.ProductId).ToList()));

            if (order == null)
                return HttpNotFound();

            Session["cart"] = null;
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Finish();

            return RedirectToAction("OrderDetails", "Order", new {id = order.Id});
        }

        public ActionResult Orders()
        {
            var viewModel = new OrderViewModel
            {
                Title = "Orders",
                Orders = _unitOfWork.Orders.GetAllOrdersByUserId(User.Identity.GetUserId())
            };

            return View(viewModel);
        }

        public ActionResult OrderDetails(int id)
        {
            var order = _unitOfWork.Orders.GetOrderByUserIdAndId(User.Identity.GetUserId(), id);

            if (order == null)
                return HttpNotFound();

            var viewModel = new OrderViewModel
            {
                Title = "Order details",
                Order = order
            };

            return View(viewModel);
        }
    }
}