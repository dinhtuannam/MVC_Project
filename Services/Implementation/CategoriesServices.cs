using Entity;
using Persistence;

namespace Services.Implementation
{
	public class CategoriesServices : ICategories
	{
		private ApplicationDbContext _context;
		public CategoriesServices(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Category> GetAll()
		{
			return _context.Categories.Where(x=>x.Status == Entity.Enums.CategoryStatus.active).ToList();
		}
	}
}
