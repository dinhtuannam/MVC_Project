namespace MVC_Project.Models
{
    public class Cart_Index_VM
    {
		public Cart_Index_VM() { 
			DiscountPrice = 0;
			CartItems = new List<Cart_item>();
		}
		public List<Cart_item> CartItems { get; set; }
		public double CartSubTotal
		{
			get { return CartItems.Sum(item => item.Total) ; }
		}
        public double CartTotal
        {
            get { return CartSubTotal + DiscountPrice + 5; }
        }
        public double DiscountPrice { get; set; }
		public string Fullname { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
	}
}
