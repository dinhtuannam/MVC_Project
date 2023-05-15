using Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Services.Implementation
{
    public class StaticsService : IStatics
    {
        private ApplicationDbContext _context;
        public StaticsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DetailOrder> GetTopSellingProducts(string filter)
        {
            var query = _context.DetailOrders.Include(p => p.Product)
                        .GroupBy(d => d.ProductId)
                        .Select(g => new
                        {
                            ProductId = g.Key,
                            TotalQuantity = g.Sum(d => d.Quantity),
                            TotalPrice = g.Sum(d => d.Total),
                            Product = g.FirstOrDefault().Product
                        });

            switch (filter)
            {
                case "best_seller":
                    query = query.OrderByDescending(g => g.TotalQuantity);
                    break;
                case "low_seller":
                    query = query.OrderBy(g => g.TotalQuantity);
                    break;
                case "highest_total":
                    query = query.OrderByDescending(g => g.TotalPrice);
                    break;
                case "lowest_total":
                    query = query.OrderBy(g => g.TotalPrice);
                    break;
                default:
                    break;
            }

            var result = query.ToList()
                .Select(r => new DetailOrder
                {
                    ProductId = r.ProductId,
                    Quantity = r.TotalQuantity,
                    Total = r.TotalPrice,
                    Product = r.Product
                }).ToList();

            return result;
        }
    }
}
