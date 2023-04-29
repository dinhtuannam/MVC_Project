using Entity.Enums;
using Entity;

namespace MVC_Project.Areas.Admin.Models
{
	public class Adm_Product_Index
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public int CategoryID { get; set; }
		public virtual Category Category { get; set; }
		public ProductStatus Status { get; set; }
		public DateTime? UploadDate { get; set; }
	}
}
