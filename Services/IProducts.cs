using Entity;

namespace Services
{
	public interface IProducts
	{
		IEnumerable<Product> GetAll();
		Product GetById(int id);

    }
}
