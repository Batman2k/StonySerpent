using System.ComponentModel;
using System.Web.Mvc;
using AutoMapper;
using StonySerpent.Core;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Title = "Create",
                ProductCategories = _unitOfWork.Categories.GetProductCategories()
            };

            return View("ProductForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            //TODO fix validation for price (wrong culture ,/.)
            if (!ModelState.IsValid)
            {
                viewModel.ProductCategories = _unitOfWork.Categories.GetProductCategories();
                return View("ProductForm", viewModel);
            }

            var product = Mapper.Map<Product>(viewModel);
            product.ProductSpecification = Mapper.Map<ProductSpecification>(viewModel);

            _unitOfWork.Products.AddProduct(product);
            _unitOfWork.Finish();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update(int id)
        {
            var product = _unitOfWork.Products.GetProductById(id);

            if (product == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<ProductFormViewModel>(product);
            //TODO CategoryId in automapper
            viewModel.ProductCategoryId = product.ProductSpecification.ProductCategoryId;
            viewModel.ProductCategories = _unitOfWork.Categories.GetProductCategories();

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ProductCategories = _unitOfWork.Categories.GetProductCategories();
                return View("ProductForm", viewModel);
            }

            var product = _unitOfWork.Products.GetProductById(viewModel.Id);

            product.Update(Mapper.Map<Product>(viewModel),
                new ProductSpecification
                {
                    ProductCategoryId = viewModel.ProductCategoryId
                });

            _unitOfWork.Finish();

            return RedirectToAction("Index", "Home");
        }
    }
}