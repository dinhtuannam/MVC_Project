using Entity;
using Persistence;

namespace Services.Implementation
{
    public class DiscountsService : IDiscounts
    {
        private ApplicationDbContext _context;
        public DiscountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Discount> GetAll()
        {
            return _context.Discounts.Where(x=>x.Status == Entity.Enums.DiscountStatus.active).ToList();
        }

        public Discount GetByName(string name)
        {
            return _context.Discounts.FirstOrDefault(x=> x.DiscountName == name);
        }

        public Discount GetById(int id)
        {
            return _context.Discounts.FirstOrDefault(m => m.DiscountId == id); ;
        }
    }
}
