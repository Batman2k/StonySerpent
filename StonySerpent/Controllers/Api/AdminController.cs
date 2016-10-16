using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using StonySerpent.Core;

namespace StonySerpent.Controllers.Api
{
    public class AdminController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult SendOrder(int orderId)
        {
            var order = _unitOfWork.Orders.GetOrderById(orderId);

            if (order == null)
                return BadRequest();

            order.OrderSent = DateTime.Now;

            _unitOfWork.Finish();

            return Ok();
        }
    }
}