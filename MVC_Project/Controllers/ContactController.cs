using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
