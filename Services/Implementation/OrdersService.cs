using Entity;
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
        public async Task CheckOut(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            var id = order.OrderId;
        }
    }
}
