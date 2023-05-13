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
using MVC_Project.Areas.Admin.models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrder : Controller
    {
        private readonly IOrders _orderService;
        private readonly ApplicationDbContext _context;
        private INotyfService _notifyService { get; }
        public AdminOrder(ApplicationDbContext context, IOrders orderService, INotyfService notifyService)
        {
            _context = context;
            _orderService = orderService;
            _notifyService = notifyService;
        }

        // GET: Admin/AdminOrder
        public IActionResult Index()
        {
            var model = _orderService.GetAll();
            return View(model);
        }

        // GET: Admin/AdminOrder/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = _orderService.GetDetailById(id);
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
            var model = new Order_update_VM
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Status = order.Status,
                OrderDate = order.OrderDate
            };
            if (order == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Admin/AdminOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Order_update_VM order)
        {
            if (id != order.OrderId)
            {
                _notifyService.Error("Không tìm thấy đơn hàng");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updateModel = new Order
                    {
                        OrderId = order.OrderId,
                        CustomerName = order.CustomerName,
                        Address = order.Address,
                        PhoneNumber = order.PhoneNumber,
                        Status = order.Status,
                        OrderDate = order.OrderDate
                    };
                    await _orderService.UpdateAsSync(updateModel);
                    _notifyService.Success("Cập nhật đơn hàng thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    _notifyService.Error("Cập nhật đơn hàng thất bại");
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
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
            await _orderService.DeleteAsSync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
