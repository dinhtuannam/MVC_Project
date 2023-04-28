namespace MVC_Project.Models
{
    public class Cart_Index_VM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total => Quantity * Price;
        public double DiscountPrice { get; set; }
    }
}
