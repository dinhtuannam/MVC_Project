using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Areas.Admin.models
{
    public class Account_Update_VM
    {
        public string Id { get; set; }
        [Display(Name = "Tên đăng nhập"), Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại"), Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Role"), Required(ErrorMessage = "Vui lòng nhập Role tài khoản")]
        public string RoleName { get; set; }
    }
}
