using Entity.Enums;
using Microsoft.AspNetCore.Identity;

namespace MVC_Project.Models
{
    public class Order_Index_VM
    {
        public int OrderId { get; set; }
        public string AccountId { get; set; }
        public virtual IdentityUser Account { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
    }
}
