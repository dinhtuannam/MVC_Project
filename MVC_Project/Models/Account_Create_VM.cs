using Entity.Enums;
using Entity;

namespace MVC_Project.Models
{
    public class Account_Create_VM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
    }
}
