using Entity;

namespace Services
{
	public interface IProducts
	{
		IEnumerable<Product> GetAll();
		Product GetById(int id);
        IEnumerable<Product> GetByCat(int catID);
        Task CreateAsSync(Product product);
        Task DeleteAsSync(int id);
        Task UpdateAsSync(Product product);
		IEnumerable<Product> FilterProduct(int CatID,string Price, string Sort);
    }
}
