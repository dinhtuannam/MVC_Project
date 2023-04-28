
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
			return _context.Products.ToList();
		}
        public Product GetById(int id)
        {
            return _context.Products.Include(p => p.Category)
                .FirstOrDefault(m => m.ProductId == id);
        }
    }
}
