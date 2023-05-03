using Entity.Enums;
using Entity;

namespace MVC_Project.Models
{
    public class Account_VM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public AccountStatus Status { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
