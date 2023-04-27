using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
	
	public class DetailOrder
	{
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; }
		[Range(0, double.MaxValue)]
		public double PricePerProduct { get; set; }
		[Range(0, double.MaxValue)]
		public double Total { get; set; }
		
	}
}
