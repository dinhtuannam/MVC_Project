using System.ComponentModel.DataAnnotations;


namespace Entity
{
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		public string? Description { get; set; }
		public string? Status { get; set; }
	}
}
