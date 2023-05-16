using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Areas.Admin.models
{
    public class Banner_Update_VM
    {
        public int Id { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(AllowEmptyStrings = true)]
        public IFormFile? BannerImage { get; set; }
        [Display(Name = "Tiêu đề"), Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả"), Required(ErrorMessage = "Vui lòng nhập chú thích")]
        public string? Description { get; set; }
    }
}
