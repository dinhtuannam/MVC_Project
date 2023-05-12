using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Areas.Admin.Models;
using MVC_Project.Models;
using PagedList.Core;
using Services;
using System.Drawing.Printing;

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

		public IActionResult Index(int page = 1, int CatID = 0 ,string Price = "none",string Sort = "none")
		{
			var pageNumber = page;
			var pageSize = 9;
			List<Product_Home_VM> ProductModel = new List<Product_Home_VM>();
			ProductModel = _productService.FilterProduct(CatID,Price,Sort).Select(product => new Product_Home_VM
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Image = product.Image,
				CategoryID = product.CategoryID,
				Category = product.Category,
				Quantity = product.Quantity,
				Price = product.Price
			}).ToList();
			var CatModel = _catService.GetAll().Select(cat => new Category_VM
			{
				CategoryID = cat.CategoryID,
				Name = cat.Name
			});
			ViewData["CategoriesList"] = CatModel;
			ViewBag.CatID = CatID;
			ViewBag.Price = Price;
			ViewBag.Sort = Sort;
			PagedList<Product_Home_VM> models = new PagedList<Product_Home_VM>(ProductModel.AsQueryable(), pageNumber, pageSize);
			return View(models);
		}

		public IActionResult Filter(int page = 1, int CatID = 0, string Price = "none", string Sort = "none")
		{
			var pageNumber = page;
			var url = $"/Product?page={page}";
			if (CatID != 0)
			{
				url += $"&CatID={CatID}";
			}
			if (Price != "none")
			{
				url += $"&Price={Price}";
			}
			if (Sort != "none")
			{
				url += $"&Sort={Sort}";
			}
			return Json(new
			{
				status = "success",
				redirectUrl = url,
			});
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
