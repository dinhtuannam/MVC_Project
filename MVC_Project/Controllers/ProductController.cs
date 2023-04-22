using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Detail(int id)
		{		
			return View();
		}
	}
}
