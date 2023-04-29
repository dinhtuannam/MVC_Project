namespace MVC_Project.Models
{
    public class Cart_Index_VM
    {
		public Cart_Index_VM() { 
			DiscountPrice = 0;
			CartItems = new List<Cart_item>();
		}
		public List<Cart_item> CartItems { get; set; }
		public double CartTotal
		{
			get { return CartItems.Sum(item => item.Total); }
		}
		public double DiscountPrice { get; set; }
	}
}
