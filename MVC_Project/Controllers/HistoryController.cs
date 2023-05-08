using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using Services;

namespace MVC_Project.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IOrders _orderService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public INotyfService _notifyService { get; }
        public HistoryController(IOrders orderService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, INotyfService notifyService)
        {
            _orderService = orderService;
            _signInManager = signInManager;
            _userManager = userManager;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                _notifyService.Information("You are not logged in to use this service. Please log in ");
                return RedirectToAction("Index", "Cart");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = _orderService.GetById(user.Id).Select(o => new Order_Index_VM
            {
                OrderId = o.OrderId,
                AccountId = o.AccountId,
                Account = o.Account,
                CustomerName = o.CustomerName,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                OrderDate = o.OrderDate,
                Status = o.Status,
                Total = o.Total
            });
            return View(model);
        }

        public IActionResult View(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                _notifyService.Information("You are not logged in to use this service. Please log in ");
                return RedirectToAction("Index", "Cart");
            }
            var model = _orderService.GetDetailById(id);
            return View(model);
        }
    }
}
