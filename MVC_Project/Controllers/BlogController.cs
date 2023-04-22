using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
