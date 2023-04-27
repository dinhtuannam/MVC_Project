using Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using Services;

namespace MVC_Project.Controllers
{
    public class DiscountController : Controller
    {
        private IDiscounts _discountService;
        public DiscountController(IDiscounts discountService)
        {
            _discountService = discountService;
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
    }
}
