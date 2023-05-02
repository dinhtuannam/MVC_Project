namespace MVC_Project.Areas.Admin.models
{
	public class Banner_Create_Update_VM
	{
		public int Id { get; set; }
		public IFormFile BannerImage { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
