using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Login_VM
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
