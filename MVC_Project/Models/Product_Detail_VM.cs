using Entity.Enums;
using Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Product_Detail_VM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
