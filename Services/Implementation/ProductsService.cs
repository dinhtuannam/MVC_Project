
using Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Services.Implementation
{
	public class ProductsService : IProducts
	{
		private ApplicationDbContext _context;
		public ProductsService(ApplicationDbContext context) {

			_context = context;
		}
		public IEnumerable<Product> GetAll()
		{
			return _context.Products
				   .Include(p => p.Category)
				   .ToList();
		}
        public Product GetById(int id)
        {
            return _context.Products.Include(p => p.Category)
                   .FirstOrDefault(m => m.ProductId == id);
        }

        public IEnumerable<Product> GetByCat(int catID)
		{
            return _context.Products
				   .Where(x => x.CategoryID == catID)
				   .Include(p => p.Category)
				   .ToList();
        }
    }
}
