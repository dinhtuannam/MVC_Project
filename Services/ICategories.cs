using Entity;

namespace Services
{
	public interface ICategories
	{
		IEnumerable<Category> GetAll();
	}
}
