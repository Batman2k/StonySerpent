using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using StonySerpent.Core;
using StonySerpent.Core.Models;

namespace StonySerpent.Controllers
{
    public class HelperController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HelperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PartialViewResult RenderCategories()
        {
            var viewModel = _unitOfWork.Categories.GetProductCategories();

            return PartialView("RenderCategories", viewModel);
        }

        public PartialViewResult RenderProducts(IEnumerable<Product> products)
        {
            return PartialView("RenderProducts", products);
        }
    }
}