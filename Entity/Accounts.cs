using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }    
    }
}