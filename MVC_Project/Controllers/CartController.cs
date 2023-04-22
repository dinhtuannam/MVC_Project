using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
	}
}
