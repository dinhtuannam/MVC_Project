using Entity.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entity
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public virtual IdentityUser Account { get; set; }
        [ForeignKey("Discount")]
		public int? DiscountId { get; set; }
		public virtual Discount Discounts { get; set; }
		[Range(0, double.MaxValue)]
		public double? DiscountPrice { get; set; }
		public DateTime OrderDate { get; set; }
		[Range(0, double.MaxValue)]
		public double Total { get; set; }
		[MaxLength(50)]
		public string CustomerName { get; set; }
		[MaxLength(50)]
		public string Address { get; set; }
		[MaxLength(12)]
		public string PhoneNumber { get; set; }
		public OrderStatus Status { get; set; }
	}
}
