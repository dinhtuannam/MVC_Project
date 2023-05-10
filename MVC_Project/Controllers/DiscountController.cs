using AspNetCoreHero.ToastNotification.Abstractions;
using Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helper;
using MVC_Project.Models;
using Services;
using Services.Implementation;

namespace MVC_Project.Controllers
{
    public class DiscountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var discounts = _context.Discounts.ToList();
            return View(discounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Code,Amount")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                _context.Discounts.Add(discount);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        public IActionResult Edit(int id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Code,Amount")] Discount discount)
        {
            if (id != discount.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(discount);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        public IActionResult Delete(int id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var discount = _context.Discounts.Find(id);
            _context.Discounts.Remove(discount);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
