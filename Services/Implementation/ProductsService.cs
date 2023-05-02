
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

        public async Task CreateAsSync(Product product)
        {
			_context.Add(product);
			await _context.SaveChangesAsync();	
        }

        public async Task DeleteAsSync(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsSync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
