
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

		public Cart_Index_VM Carts
		{
			get
			{
				var data = HttpContext.Session.Get<Cart_Index_VM>("GioHang");
				if (data == null)
				{
					data = new Cart_Index_VM();
				}
				return data;
			}
		}

		[HttpGet]
		public IActionResult AddToCart(int id,int qty)
		{
			var myCart = Carts;
			var item = myCart.CartItems.FirstOrDefault(x => x.ProductId == id);
			var cart_item = new Cart_item();
			if (item == null)
			{
				var product = _productService.GetById(id);
				cart_item = new Cart_item
				{
					ProductId = id,
					Name = product.Name,
					Image = product.Image,
					Quantity = qty,
					PricePerProduct = product.Price,
				};
				myCart.CartItems.Add(cart_item);
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
