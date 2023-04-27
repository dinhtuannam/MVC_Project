using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Discount_VM
    {
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public double DiscountPrice { get; set; }
        public string? Description { get; set; }
        public DiscountStatus Status { get; set; }
    }
}
