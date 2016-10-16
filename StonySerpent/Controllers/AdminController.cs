using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StonySerpent.Core;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Orders()
        {

            var viewModel = new AdminViewModel
            {
                Orders = _unitOfWork.Orders.GetAllUnsentOrders()
            };

            return View(viewModel);
        }
    }

    public class AdminViewModel
    {
        public List<Order> Orders { get; set; }
        public string Title { get; set; }
    }
}