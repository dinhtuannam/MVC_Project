using Entity.Enums;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
	public class Discount
	{
		[Key]
		public int DiscountId { get; set; }
		[MaxLength(50)]
		public string DiscountName { get; set; }
		[Range(0, double.MaxValue)]
		public double DiscountPrice { get; set; }
		public string? Description { get; set; }
		public DiscountStatus Status { get; set; }
	}
}
