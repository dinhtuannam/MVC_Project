using MVC_Project.Models;
using System.Security.Claims;
namespace MVC_Project.Helper
{
    public static class ClaimsIdentityExtensions
    {
        public static void UpdateUserData(this ClaimsIdentity identity, Account_VM user)
        {
            // Xóa các thông tin người dùng cũ
            identity.RemoveClaim(identity.FindFirst(ClaimTypes.Name));
            identity.RemoveClaim(identity.FindFirst(ClaimTypes.Email));
            // Thêm thông tin người dùng mới
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            // Thêm các thông tin người dùng khác cần cập nhật
            // identity.AddClaim(new Claim("Tên thuộc tính", user.Property));
            // ...
        }
    }
}
