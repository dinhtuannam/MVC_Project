using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			var model = new Login_VM();
			return View(model);
		}
	}
}
