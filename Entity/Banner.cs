using System.ComponentModel.DataAnnotations;


namespace Entity
{
	public class Banner
	{
		[Key]
		public int Id { get; set; }
		public string BannerImage { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
