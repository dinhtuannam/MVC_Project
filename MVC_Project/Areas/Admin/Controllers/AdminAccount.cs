using AspNetCoreHero.ToastNotification.Abstractions;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Areas.Admin.models;
using MVC_Project.Helper;
using Services;
using Services.Implementation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
/*    [Authorize(Roles = "Admin")]*/
    public class AdminAccount : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private INotyfService _notifyService { get; }
        public AdminAccount(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, INotyfService notifyService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
            _notifyService = notifyService;
		}
		public IActionResult Index()
		{
			var users = _userManager.Users.ToList().Select(u => new Account_Index_VM
			{
				Id = u.Id,
				UserName = u.UserName,
				Email = u.Email,
				PhoneNumber = u.PhoneNumber,
				Password = u.PasswordHash
			});
			return View(users);
		}

		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
				return NotFound();
			else
			{
                var user = await _userManager.FindByIdAsync(id);
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles[0];

				var model = new Account_Detail_VM
				{
					Id = id,
					UserName = user.UserName,
					Password = user.PasswordHash,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					RoleName = roleName
				};
				return View(model);
            }
		}

		public async Task<IActionResult> Edit(string id)
		{
            if (id == null)
                return NotFound();
            else
            {
                var user = await _userManager.FindByIdAsync(id);
                var roles = await _userManager.GetRolesAsync(user);                      
                var model = new Account_Update_VM
                {
                    Id = id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RoleName = roles[0]
                };
                var roleList = await _roleManager.Roles.ToListAsync();
                ViewData["RoleList"] = new SelectList(roleList, "Name", "Name");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Account_Update_VM model)
        {
            if (ModelState.IsValid)
            {
                // ========================  Cập nhật thông tin thông thường =========================
                var user = await _userManager.FindByIdAsync(model.Id);
                if(user.UserName != model.UserName)
                {
                    var findUserName =  _userManager.Users.FirstOrDefault(p => p.UserName == model.UserName);
                    if (findUserName != null)
                    {
                        _notifyService.Error("Tên đăng nhập đã có người sử dụng. Vui lòng chọn tên khác!");
                        return View(model);
                    }
                    else
                        user.UserName = model.UserName;
                }
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật thông tin người dùng");
                    return View(model);
                }
                // ===========================  Cập nhật Role tài khoản  =============================
                var currentRole = await _userManager.GetRolesAsync(user);
                if (model.RoleName != currentRole[0])
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, currentRole[0]);
                    if (!removeRoleResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi xóa vai trò cũ của người dùng");
                        return View(model);
                    }
                    result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!removeRoleResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi xóa vai trò cũ của người dùng");
                        return View(model);
                    }
                }
                // ============================== Cập nhật tài khoản ==================================
                await _userManager.UpdateSecurityStampAsync(user);
                _notifyService.Success("Cập nhật tài khoản thành công");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new Account_Create_VM();
            var roleList = await _roleManager.Roles.ToListAsync();
            ViewData["RoleList"] = new SelectList(roleList, "Name", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account_Create_VM model)
        {
            if (ModelState.IsValid)
            {
                var findUserName = await _userManager.FindByNameAsync(model.UserName);
                if(findUserName != null)
                {
                    if(model.UserName == findUserName.UserName)
                    {
                        _notifyService.Error("Tên tài khoản đã có người sử dụng!");
                        var roleList = await _roleManager.Roles.ToListAsync();
                        ViewData["RoleList"] = new SelectList(roleList, "Name", "Name");
                        return View(model);
                    }             
                }
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByEmailAsync(model.Email);
                    await _userManager.AddToRoleAsync(newUser, model.RoleName);
                    _notifyService.Success("Create account successfully");
                    return RedirectToAction("Index", "AdminAccount");
                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        _notifyService.Error(error.Code);
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var roleList = await _roleManager.Roles.ToListAsync();
                    ViewData["RoleList"] = new SelectList(roleList, "Name", "Name");
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
