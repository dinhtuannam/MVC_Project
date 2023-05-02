using Microsoft.AspNetCore.Mvc;
using MVC_Project.Areas.Admin.models;
using MVC_Project.Models;
using Services;
using System.Diagnostics;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBanners _bannerService;

        public HomeController(ILogger<HomeController> logger, IBanners bannerService)
        {
            _logger = logger;
            _bannerService = bannerService;
        }

        public IActionResult Index()
        {
            var model = _bannerService.GetAll().Select(b => new Banner_Admin_Index
            {
                Id = b.Id,
                Title = b.Title,
                BannerImage = b.BannerImage,
                Description = b.Description
            });
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}