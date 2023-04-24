using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entity.Enums;
namespace Entity
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		[Required,MaxLength(50)]
		public string Name { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public int Quantity { get; set; }
		[Range(0, double.MaxValue)]
		public double Price { get; set; }
		[ForeignKey("Category")]
		public int CategoryID { get; set; }
		public virtual Category Category { get; set; }
		public ProductStatus Status { get; set; }
		public DateTime? UploadDate { get; set; }
	}
}
