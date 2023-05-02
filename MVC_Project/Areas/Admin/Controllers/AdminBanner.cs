using AspNetCoreHero.ToastNotification.Abstractions;
using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Areas.Admin.models;
using MVC_Project.Helper;
using Services;
using Services.Implementation;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBanner : Controller
    {
        private IBanners _bannerService;
        private INotyfService _notifyService { get; }
        private IWebHostEnvironment _webHostEnvironment;
        public AdminBanner(IBanners bannerService, INotyfService notifyServic, IWebHostEnvironment webHostEnvironment)
        {
            _bannerService = bannerService;
            _notifyService = notifyServic;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: AdminBanner
        public ActionResult Index()
        {
            var model = _bannerService.GetAll().Select(b => new Banner_Admin_Index
            {
                Id = b.Id,
                BannerImage = b.BannerImage,
                Title = b.Title,
                Description = b.Description
            });
            return View(model);
        }

        // GET: AdminBanner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminBanner/Create
        public ActionResult Create()
        {
            var model = new Banner_Create_Update_VM();
            return View(model);
        }

        // POST: AdminBanner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner_Create_Update_VM model)
        {
            try
            {
                var newBanner = new Banner
                {
                    Title = model.Title,
                    Description = model.Description
                };
                if (model.BannerImage != null && model.BannerImage.Length > 0)
                {
                    var helper = new ConvertImgToString(_webHostEnvironment);
                    newBanner.BannerImage = helper.ConvertImg(model.BannerImage,"Banner").Result;
                    await _bannerService.CreateAsSync(newBanner);
                    _notifyService.Success("Thêm banner thành công!");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminBanner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminBanner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AdminBanner/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    await _bannerService.DeleteAsSync(id);
                    _notifyService.Success("Xóa sản phẩm thành công");
                    return Json(new
                    {
                        status = "success"
                    });
                }
                return Json(new
                {
                    status = "fail"
                });
            }
            catch
            {
                return View();
            }
        }
    }
}
