
using AspNetCoreHero.ToastNotification.Abstractions;
using Entity;
using Entity.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helper;
using MVC_Project.Models;
using Services;


namespace MVC_Project.Controllers
{
	public class CartController : Controller
	{
		//  ===============  Identity
		private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        //  ===============  Service
        private IProducts _productService;
        private IOrders _orderService;
        //  ===============  Helper
		public INotyfService _notifyService { get; }
    
		
		public CartController(IProducts productService,IOrders orderService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, INotyfService notifyService)
		{
			_productService = productService;
			_signInManager = signInManager;
			_notifyService = notifyService;
			_userManager = userManager;
			_orderService = orderService;
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

		[HttpGet]
		public async Task<IActionResult> Checkout()
		{
			if(!_signInManager.IsSignedIn(User)){
				_notifyService.Information("You are not logged in to use this service. Please log in ");				
                return RedirectToAction("Index", "Cart");
            }
			else
			{
				List<DetailOrder> DetailOrderModel = new List<DetailOrder>();
                var _session = new SessionStorage();
                var CartSession = _session.GetCart(HttpContext);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
				var CartModel = new Order
				{
					AccountId = user.Id,
					OrderDate = DateTime.Now,
					DiscountPrice = CartSession.DiscountPrice,
					Total = CartSession.CartTotal,
					CustomerName = "abc",
					Address = "abc",
					PhoneNumber = "abc",
					Status = OrderStatus.unconfirmed
				};
                foreach (var cartItem in CartSession.CartItems)
				{
					var detailOrder = new DetailOrder
					{

					};
				}
                await _orderService.CheckOut(CartModel);
				_session.DeleteCart(HttpContext);
                _notifyService.Success("Check out successfully !");
                return RedirectToAction("Index", "Home");
			}
		}
	}
}
