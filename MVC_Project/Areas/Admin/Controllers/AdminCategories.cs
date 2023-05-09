using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCategories : Controller
    {
        // GET: AdminCategories
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminCategories/Edit/5
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

        // GET: AdminCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminCategories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
