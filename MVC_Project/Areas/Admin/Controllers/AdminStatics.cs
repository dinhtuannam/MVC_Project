using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminStatics : Controller
    {
        private readonly IStatics _staticsService;
        public AdminStatics(IStatics staticsService)
        {
            _staticsService = staticsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TopSeller(string filter = "best_seller")
        {
            var model = _staticsService.GetTopSellingProducts(filter);
            ViewBag.filterSelected = filter;
            return View(model);
        }

        
    }
}
