using System.ComponentModel.DataAnnotations;

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
            get { return CartSubTotal - DiscountPrice + 5; }
        }
        public int? DiscountId { get; set; }
        public double DiscountPrice { get; set; }
        [Required(ErrorMessage = "Customer name cannot be required")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Address cannot be required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number cannot be required")]
        public string PhoneNumber { get; set; }
	}
}
