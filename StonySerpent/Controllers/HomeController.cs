using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StonySerpent.Core;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string searchTerm = null)
        {
            var viewModel = new HomeViewModel
            {
                Title = "Main Page",
                SearchTerm = searchTerm
            };

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                viewModel.Title = "Searched for" + searchTerm;
                viewModel.Products = _unitOfWork.Products.SearchProducts(searchTerm);
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category(string category)
        {
            var viewModel = new HomeViewModel
            {
                Title = category,
                Products = _unitOfWork.Products.GetAllProductsFromCategory(category)
            };

            if (viewModel.Products.FirstOrDefault() == null)
                return HttpNotFound();

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var products = new List<Product>
            {
                _unitOfWork.Products.GetProductById(id)
            };

            if (products.FirstOrDefault() == null)
                return HttpNotFound();

            var viewModel = new HomeViewModel
            {
                Title = "Details for " + products.First().Name,
                Products = products
            };

            return View(viewModel);
        }
    }
}