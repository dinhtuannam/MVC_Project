using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Areas.Admin.models
{
    public class Banner_Admin_Index
    {
        public int Id { get; set; }
		[Display(Name = "Hình ảnh"), Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
		public string BannerImage { get; set; }
		[Display(Name = "Tiêu đề"), Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
		public string Title { get; set; }
        public string? Description { get; set; }
    }
}
