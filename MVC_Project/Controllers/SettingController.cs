using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Areas.Admin.models;
using MVC_Project.Helper;
using MVC_Project.Models;
using Services.Implementation;
using System.Security.Claims;

namespace MVC_Project.Controllers
{
    public class SettingController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public INotyfService _notifyService { get; }
        public SettingController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,INotyfService notifyService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                _notifyService.Information("You are not logged in to use this service. Please log in ");
                return RedirectToAction("Login", "Account");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new Account_VM
            {
                Id = user.Id,
                Username = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            return View(model);
        }

        public async Task<IActionResult> ChangePassword()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                _notifyService.Information("You are not logged in to use this service. Please log in ");
                return RedirectToAction("Login", "Account");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new Password_Update_VM
            {
                Id = user.Id,
                HashPassword = user.PasswordHash
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(Password_Update_VM model)
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Information("Dữ liệu không hợp lệ");
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                _notifyService.Success("Update password successfully!");
                return RedirectToAction("Index", "Setting");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    _notifyService.Error("Password do not correct");
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                // Xử lý logic khi thay đổi mật khẩu không thành công
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Account_VM model)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                _notifyService.Information("You are not logged in to use this service. Please log in ");
                return RedirectToAction("Login", "Account");
            }
            var currentUser = await _userManager.FindByIdAsync(model.Id);
            if (currentUser.UserName != model.Username)
            {
                var findUserName = _userManager.Users.FirstOrDefault(p => p.UserName == model.Username);
                if (findUserName != null)
                {
                    _notifyService.Error("Tên đăng nhập đã có người sử dụng. Vui lòng chọn tên khác!");
                    return RedirectToAction("Index", "Setting");
                }
                else
                    currentUser.UserName = model.Username;
            }
            currentUser.Email = model.Email;
            currentUser.PhoneNumber = model.Phone;
            var result = await _userManager.UpdateAsync(currentUser);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật thông tin người dùng");
                return View(model);
            }
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, isPersistent: false);
            _notifyService.Success("Update account successfully");
            return RedirectToAction("Index", "Setting");
        }
    }
}
