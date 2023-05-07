using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Carts
    {
        public List<CartItems> CartItems { get; set; }
        public double CartSubTotal
        {
            get { return CartItems.Sum(item => item.Total); }
        }
        public double CartTotal
        {
            get { return CartSubTotal + DiscountPrice + 5; }
        }
        public int? DiscountId { get; set; }
        public double DiscountPrice { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
