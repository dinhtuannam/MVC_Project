using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using Services;

namespace MVC_Project.Controllers
{
	public class ProductController : Controller
	{
		private IProducts _productService;
		private IWebHostEnvironment _webHostEnvironment;

		public ProductController(IProducts productService, IWebHostEnvironment webHostEnvironment)
		{
			_productService = productService;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			var model = _productService.GetAll().Select(product => new Product_Home_VM
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Image = product.Image,
				Quantity = product.Quantity,
				Price = product.Price
			});
			return View(model);
		}
		public IActionResult Detail(int id)
		{		
			return View();
		}
	}
}
