using AspNetCoreHero.ToastNotification.Abstractions;
using Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helper;
using MVC_Project.Models;
using Services;
using Services.Implementation;

namespace MVC_Project.Controllers
{
    public class DiscountController : Controller
    {
        private IDiscounts _discountService;
        public INotyfService _notifyService { get; }
        public DiscountController(IDiscounts discountService, INotyfService notifyService)
        {
            _discountService = discountService;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDiscount(string name)
        {
            var model = _discountService.GetByName(name);
            if (model == null)
            {
                return null;
            }
            var discountModel = new Discount_VM
            {
                DiscountId = model.DiscountId,
                DiscountName = model.DiscountName,
                DiscountPrice = model.DiscountPrice,
                Description = model.Description,
                Status = model.Status
            };
            return Json(discountModel);
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
        public IActionResult ApplyDiscount(string? name)
        {
            if(name == null)
                return View();
            var myCart = Carts;
            var model = _discountService.GetByName(name);
            if (model == null)
            {
                _notifyService.Information("Discount not found");
                return Json(new
                {
                    status = "notfound",
                });
            }
            var discountModel = new Discount_VM
            {
                DiscountId = model.DiscountId,
                DiscountName = model.DiscountName,
                DiscountPrice = model.DiscountPrice,
                Description = model.Description,
                Status = model.Status
            };
            myCart.DiscountPrice = discountModel.DiscountPrice;
            HttpContext.Session.Set("GioHang", myCart);
            _notifyService.Success("Apply discount successfully");
            return Json(new
            {   
                status = "success",
            });
        }

        [HttpGet]
        public IActionResult CancelDiscount()
        {
            var myCart = Carts;
            myCart.DiscountPrice = 0;
            HttpContext.Session.Set("GioHang", myCart);
            _notifyService.Success("Cancel discount successfully");
            return Json(new
            {
                status = "success",
            });
        }
    }
}
