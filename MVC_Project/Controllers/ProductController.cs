using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Models;
using Services;

namespace MVC_Project.Controllers
{
	public class ProductController : Controller
	{
		private IProducts _productService;
		private ICategories _catService;
		private IWebHostEnvironment _webHostEnvironment;

		public ProductController(IProducts productService, ICategories catService, IWebHostEnvironment webHostEnvironment)
		{
			_productService = productService;
			_webHostEnvironment = webHostEnvironment;
			_catService = catService;
		}

		public IActionResult Index()
		{
			var ProductModel = _productService.GetAll().Select(product => new Product_Home_VM
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Image = product.Image,
				Quantity = product.Quantity,
				Price = product.Price
			});
			var CatModel = _catService.GetAll().Select(cat => new Category_VM
			{
				CategoryID = cat.CategoryID,
				Name = cat.Name
			});
			var ViewModel = new Product_Category_VM
			{
				Products = ProductModel,
				Categories = CatModel
			};
			return View(ViewModel);
		}
		public IActionResult Detail(int id)
		{
			var model = _productService.GetById(id);
			if (model == null)
				return NotFound();
			var productModel = new Product_Detail_VM { 
				ProductId = model.ProductId,
				Name = model.Name,	
				Image = model.Image,
				Quantity = model.Quantity,
				Price = model.Price,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                CategoryID = model.CategoryID,
                Status = model.Status,
				Category = model.Category,
				UploadDate = model.UploadDate
            };
			return View(productModel);
		}
	}
}
