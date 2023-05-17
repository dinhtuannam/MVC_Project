using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Password_Update_VM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Current Password cannot be required")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "New Password cannot be required")]
        public string NewPassword { get; set; }
        public string HashPassword { get; set; }
    }
}
