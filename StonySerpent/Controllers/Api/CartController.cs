using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using StonySerpent.Core.Models;

//using System.Web.Mvc;

namespace StonySerpent.Controllers.Api
{
    public class CartController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(int productId, double price)
        {
            var session = SessionStateUtility.GetHttpSessionStateFromContext(HttpContext.Current);
            var cartProducts = (List<CartProduct>) session["cart"];

            if (cartProducts == null)
                cartProducts = new List<CartProduct>
                {
                    new CartProduct(productId, price)
                };
            else
            {
                var isFound = false;
                foreach (var cartProduct in cartProducts)
                {
                    if (!cartProduct.ProductId.Equals(productId)) continue;

                    cartProduct.Amount++;
                    isFound = true;
                    break;
                }
                if (!isFound)
                {
                    cartProducts.Add(new CartProduct(productId, price));
                }
            }

            cartProducts.Sort((product, cartProduct) =>
                product.ProductId.CompareTo(cartProduct.ProductId));


            session["cart"] = cartProducts;

            return Ok();
        }

        //TODO remove webcontroller fix js for this
        [HttpPost]
        public IHttpActionResult Cart(CartProduct cartProduct)
        {
            var session = SessionStateUtility.GetHttpSessionStateFromContext(HttpContext.Current);
            var cart = (List<CartProduct>) session["cart"];
            var productInCart = cart.FirstOrDefault(p => p.ProductId == cartProduct.ProductId);

            if (productInCart != null)
                productInCart.Amount = cartProduct.Amount;

            cart.RemoveAll(p => p.Amount == 0);

            session["cart"] = cart;

            return Ok();
        }

        //TODO Delete?
        public List<CartProduct> GetCart()
        {
            var session = SessionStateUtility.GetHttpSessionStateFromContext(HttpContext.Current);

            return (List<CartProduct>) session["cart"];
        }
    }
}