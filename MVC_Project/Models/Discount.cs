using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Amount { get; set; }
    }

}
