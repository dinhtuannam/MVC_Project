using Microsoft.AspNetCore.Mvc;
using Services;

namespace MVC_Project.Controllers
{
	public class OrderController : Controller
	{
		private IOrders _orderService;
		public OrderController(IOrders orderService)
		{
			_orderService = orderService;
		}
		public IActionResult Index()
		{
			return View();
		}
		
	}
}
