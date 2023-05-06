using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CartItems
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double PricePerProduct { get; set; }
        public double Total => Quantity * PricePerProduct;
    }
}
