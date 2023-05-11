
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

        public IEnumerable<Product> FilterProduct(int CatID, string Price, string Sort)
		{
			var products = _context.Products.AsQueryable();
            if (CatID != 0)
            {
                products = products.Where(p => p.CategoryID == CatID);
            }
            if(Price != "none")
            {
				switch (Price)
				{
					case "under_100":
                        products = products.Where(p => p.Price < 100);
						break;
					case "100_to_1000":
                        products = products.Where(p => p.Price >= 100 && p.Price <= 1000);
						break;
					case "over_1000":
						products = products.Where(p => p.Price > 1000);
						break;
					default:
						break;
				}
			}
            if(Sort != "none")
            {
				switch (Sort)
				{
					case "by_title":
						products = products.OrderBy(p => p.Name);
						break;
					case "by_price_asc":
						products = products.OrderBy(p => p.Price);
						break;
					case "by_price_desc":
						products = products.OrderByDescending(p => p.Price);
						break;
					default:
						break;
				}
			}		
			return products.ToList();
        }
    }
}
