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

        public async Task DeleteAsSync(int id)
        {
            var detailOrderDelete = GetDetailById(id);
            _context.DetailOrders.RemoveRange(detailOrderDelete);
            await _context.SaveChangesAsync();

            var orderDelete = GetOrderById(id);
            _context.Orders.Remove(orderDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                    .Include(o => o.Account)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
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

        public Order GetOrderById(int orderID)
        {
            try
            {
                return _context.Orders.FirstOrDefault(x => x.OrderId == orderID);
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

        public async Task UpdateAsSync(Order order)
        {
            var getOrder = GetOrderById(order.OrderId);
                getOrder.CustomerName = order.CustomerName;
                getOrder.Address = order.Address;
                getOrder.PhoneNumber = order.PhoneNumber;
                getOrder.OrderDate = order.OrderDate;
                getOrder.Status = order.Status;
            _context.SaveChanges();
        }
        
    }
}
