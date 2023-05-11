using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Product_Home_VM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
		public int CategoryID { get; set; }
		public virtual Category Category { get; set; }
		public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
