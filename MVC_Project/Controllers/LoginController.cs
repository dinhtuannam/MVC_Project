using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
