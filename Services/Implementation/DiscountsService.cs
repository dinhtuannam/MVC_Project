using Entity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class DiscountsService : IDiscounts
    {
        private ApplicationDbContext _context;
        public DiscountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Discount GetByName(string name)
        {
            return _context.Discounts.FirstOrDefault(x=> x.DiscountName == name);
        }
    }
}
