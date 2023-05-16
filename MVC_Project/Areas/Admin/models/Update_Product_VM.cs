using Entity;
using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Areas.Admin.models
{
    public class Update_Product_VM
    {
        public int ProductId { get; set; }
        [StringLength(50), Display(Name = "Tên sản phẩm"), Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Mô tả"), Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        public string Description { get; set; }
        [Display(Name = "Mô tả ngắn"), Required(ErrorMessage = "Vui lòng nhập mô tả ngắn sản phẩm")]
        public string ShortDescription { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(AllowEmptyStrings = true)]
        public IFormFile Image { get; set; }
        [Display(Name = "Số lượng"), Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Giá tiền"), Required(ErrorMessage = "Vui lòng nhập giá tiền")]
        public double Price { get; set; }
        
        public int CategoryID { get; set; }
        [Display(Name = "Trạng thái")]
        public ProductStatus Status { get; set; }
        [DataType(DataType.Date), Display(Name = "Ngày tải lên")]
        public DateTime? UploadDate { get; set; }
    }
}
