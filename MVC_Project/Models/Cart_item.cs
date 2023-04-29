namespace MVC_Project.Models
{
	public class Cart_item
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Quantity { get; set; }
		public double PricePerProduct { get; set; }
		public double Total => Quantity * PricePerProduct;
		
	}
}
