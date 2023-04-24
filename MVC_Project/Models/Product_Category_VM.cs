using Entity;

namespace MVC_Project.Models
{
	public class Product_Category_VM
	{
		public IEnumerable<Product_Home_VM> Products { get; set; }
		public IEnumerable<Category_VM> Categories { get; set; }
	}
}
