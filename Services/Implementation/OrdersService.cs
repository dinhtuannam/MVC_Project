using Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OrdersService : IOrders
    {
        private readonly ApplicationDbContext _context;
        public OrdersService(ApplicationDbContext context) {
            _context = context;
        }

        public IEnumerable<Order> GetById(string id)
        {
            try
            {
               return  _context.Orders
                    .Where(o => o.AccountId == id)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<DetailOrder> GetDetailById(int id)
        {
            try
            {
                return _context.DetailOrders.Include(x => x.Product).Where(x => x.OrderId == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task InsertDetailOrder(List<DetailOrder> detailOrder)
        {
            try
            {
                _context.DetailOrders.AddRange(detailOrder);
                await _context.SaveChangesAsync();
            }
            catch
            {

            }
        }

        public async Task<Order> InsertOrder(Order order)
        {
            try
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch
            {
                return null;
            }
            
        }
    }
}
