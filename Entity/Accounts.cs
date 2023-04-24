using Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Username { get; set; }
        [Required,MaxLength(50)]
        public string Password { get; set; }    
        public DateTime CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public AccountStatus Status { get; set; }
		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}