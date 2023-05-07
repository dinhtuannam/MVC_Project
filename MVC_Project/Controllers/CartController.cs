
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
    
		
		public CartController(
			IProducts productService,
			IOrders orderService, 
			SignInManager<IdentityUser> signInManager, 
			UserManager<IdentityUser> userManager, 
			INotyfService notifyService)
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

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Cart_Index_VM request)
		{
            var _session = new SessionStorage();
            var CartSession = _session.GetCart(HttpContext);
			if(CartSession.CartItems.Count == 0)
			{
                _notifyService.Error("Your cart is empty!");
                return RedirectToAction("Index", "Home");
            }
            if (!_signInManager.IsSignedIn(User)){
				_notifyService.Information("You are not logged in to use this service. Please log in ");				
                return RedirectToAction("Index", "Cart");
            }
			else
			{
				List<DetailOrder> DetailOrderModel = new List<DetailOrder>();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
				var CartModel = new Order
				{
					AccountId = user.Id,
					OrderDate = DateTime.Now,
					DiscountId = CartSession.DiscountId,
					DiscountPrice = CartSession.DiscountPrice,
					Total = CartSession.CartTotal,
					CustomerName = request.Fullname,
					Address = request.Address,
					PhoneNumber = request.PhoneNumber,
					Status = OrderStatus.unconfirmed
				};
                var insertOrder = await _orderService.InsertOrder(CartModel);
                foreach (var cartItem in CartSession.CartItems)
				{
					var detailOrder = new DetailOrder
					{
						OrderId = insertOrder.OrderId,
						ProductId = cartItem.ProductId,
						Quantity = cartItem.Quantity,
						PricePerProduct = cartItem.PricePerProduct,
						Total = cartItem.Total
					};
                    DetailOrderModel.Add(detailOrder);
				}
				await _orderService.InsertDetailOrder(DetailOrderModel);
				_session.DeleteCart(HttpContext);
                _notifyService.Success("Check out successfully !");
                return RedirectToAction("Index", "Home");
			}
		}

        [HttpGet]
        public IActionResult DeleteCartItem(int id)
		{
            var _session = new SessionStorage();
            var CartSession = _session.GetCart(HttpContext);
            var deletedItem = CartSession.CartItems.SingleOrDefault(item => item.ProductId == id);
			if(deletedItem != null) {
				CartSession.CartItems.Remove(deletedItem);
                _notifyService.Success("Deleted successfully !");
                HttpContext.Session.Set("GioHang", CartSession);
                return Json(new
                {
					errCode = 0,
                    status = "success",
                });
            }
			else
			{
                _notifyService.Error("Deleted fail . Please try again !");
                return Json(new
                {
                    errCode = -1,
                    status = "fail",
                });
            }
        }
            
    }
}
