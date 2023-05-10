using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity;
using Persistence;
using Services;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrder : Controller
    {
        private readonly IOrders _orderService;
        private readonly ApplicationDbContext _context;

        public AdminOrder(ApplicationDbContext context, IOrders orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        // GET: Admin/AdminOrder
        public IActionResult Index()
        {
            var model = _orderService.GetAll();
            return View(model);
        }

        // GET: Admin/AdminOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Discounts)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/AdminOrder/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountName");
            return View();
        }

        // POST: Admin/AdminOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,AccountId,DiscountId,DiscountPrice,OrderDate,Total,CustomerName,Address,PhoneNumber,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Users, "Id", "Id", order.AccountId);
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountName", order.DiscountId);
            return View(order);
        }

        // GET: Admin/AdminOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Users, "Id", "Id", order.AccountId);
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountName", order.DiscountId);
            return View(order);
        }

        // POST: Admin/AdminOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,AccountId,DiscountId,DiscountPrice,OrderDate,Total,CustomerName,Address,PhoneNumber,Status")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Users, "Id", "Id", order.AccountId);
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountName", order.DiscountId);
            return View(order);
        }

        // GET: Admin/AdminOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Discounts)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
