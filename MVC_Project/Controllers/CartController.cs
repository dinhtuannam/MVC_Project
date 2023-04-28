
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helper;
using MVC_Project.Models;
using Services;


namespace MVC_Project.Controllers
{
	public class CartController : Controller
	{
		private IProducts _productService;
		public INotyfService _notifyService { get; }
		public CartController(IProducts productService, INotyfService notifyService)
		{
			_productService = productService;
			_notifyService = notifyService;
		}

        public IActionResult Index()
		{
			return View(Carts);
		}

		public List<Cart_Index_VM> Carts
		{
			get
			{
				var data = HttpContext.Session.Get<List<Cart_Index_VM>>("GioHang");
				if (data == null)
				{
					data = new List<Cart_Index_VM>();
				}
				return data;
			}
		}

		[HttpGet]
		public IActionResult AddToCart(int id,int qty)
		{
			var myCart = Carts;
			var item = myCart.SingleOrDefault(p => p.ProductId == id);
			if (item == null)
			{
				var product = _productService.GetById(id);
				item = new Cart_Index_VM
				{
					ProductId = id,
					Name = product.Name,
					Image = product.Image,
					Quantity = qty,
					Price = product.Price,
					DiscountPrice = 0
				};
				myCart.Add(item);
			}
			else
			{
				item.Quantity += qty;
			}
			HttpContext.Session.Set("GioHang", myCart);
			_notifyService.Success("Add product successfully");
			return Json(new
			{
				status = "success",
			});
		}
	}
}
