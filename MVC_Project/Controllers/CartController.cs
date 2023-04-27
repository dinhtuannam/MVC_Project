using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			var model = new Cart_Index_VM
			{
				DiscountPrice = 0,
			};
			return View(model);
		}

		
	}
}
