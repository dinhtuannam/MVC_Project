using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Areas.Admin.models;
using MVC_Project.Areas.Admin.Models;
using Services;
using PagedList.Core;
using MVC_Project.Models;
using MVC_Project.Helper;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProduct : Controller
	{
		private IProducts _productService;
		private ICategories _categories;
        private INotyfService _notifyService { get; }
        private IWebHostEnvironment _webHostEnvironment;
        public AdminProduct(IProducts productService, ICategories categories, IWebHostEnvironment webHostEnvironment, INotyfService notifyService)
		{
			_productService = productService;
			_categories = categories;
            _webHostEnvironment = webHostEnvironment;
            _notifyService = notifyService;
		}

		public async Task<IActionResult> Index(int page = 1, int CatID = 0)
		{
            var pageNumber = page;
            var pageSize = 10;
            List<Adm_Product_Index> lsProducts = new List<Adm_Product_Index>();
			if(CatID == 0){
				lsProducts = _productService.GetAll().Select(p => new Adm_Product_Index
				{
					ProductId = p.ProductId,
					Name = p.Name,
					Image = p.Image,
					Quantity = p.Quantity,
					Price = p.Price,
					CategoryID = p.CategoryID,
					Category = p.Category,
					Status = p.Status,
					UploadDate = p.UploadDate
				}).ToList();
			}
			else
			{
                lsProducts = _productService.GetByCat(CatID).Select(p => new Adm_Product_Index
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Image = p.Image,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    CategoryID = p.CategoryID,
                    Category = p.Category,
                    Status = p.Status,
                    UploadDate = p.UploadDate
                }).ToList();
            }
			var lstCat = _categories.GetAll().Select(c => new Category_ViewData
			{
				CategoryID = c.CategoryID,
				Name = c.Name
			});
            ViewBag.CurrentCatID = CatID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["CategoriesList"] = new SelectList(lstCat, "CategoryID", "Name", CatID);
            PagedList<Adm_Product_Index> models = new PagedList<Adm_Product_Index>(lsProducts.AsQueryable(), pageNumber, pageSize);
            return View(models);
		}

        public IActionResult Filter(int page = 1, int CatID = 0, int Active = 0)
        {
            var pageNumber = page;
            var url = $"/Admin/AdminProduct?CatID={CatID}&Active={Active}";
            if (CatID == 0 & Active == 0)
            {
                url = $"/Admin/AdminProduct";
            }
            else
            {
                if (Active == 0)
                    url = $"/Admin/AdminProduct?CatID={CatID}";
                if (CatID == 0)
                    url = $"/Admin/AdminProduct?Active={Active}";
            }
            return Json(new
            {
                status = "success",
                redirectUrl = url,
            });
        }

        public IActionResult Detail(int id)
        {
            var model = _productService.GetById(id);
            if (model == null)
                return NotFound();
            var productModel = new Product_Detail_VM
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Image = model.Image,
                Quantity = model.Quantity,
                Price = model.Price,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                CategoryID = model.CategoryID,
                Status = model.Status,
                UploadDate = model.UploadDate
            };
            return View(productModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Create_Product_VM();
            var lstCat = _categories.GetAll().Select(c => new Category_ViewData
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
            ViewData["CategoriesList"] = new SelectList(lstCat, "CategoryID", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create_Product_VM model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    ShortDescription = model.ShortDescription,
                    Quantity = model.Quantity,
                    Price = model.Price,    
                    CategoryID = model.CategoryID,
                    Status = model.Status,
                    UploadDate = model.UploadDate
                };
                //await employeeService.CreateAsSync(employee);
                if (model.Image != null && model.Image.Length > 0)
                {
                    var convert = new ConvertImgToString(_webHostEnvironment);
                    newProduct.Image = convert.ConvertImg(model.Image,"Sneaker").Result;
                    await _productService.CreateAsSync(newProduct);
                    _notifyService.Success("Thêm sản phẩm thành công!");
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            /*var product = _productService.GetById(id);*/
            if (id != null)
            {
                await _productService.DeleteAsSync(id);
                _notifyService.Success("Xóa sản phẩm thành công");
                /*var helper = new ConvertImgToString(_webHostEnvironment);
                helper.DeleteImg(product.Image);*/
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

        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new Update_Product_VM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                CategoryID = product.CategoryID,
                Quantity = product.Quantity,
                Price = product.Price,
                Status = product.Status,
                UploadDate = product.UploadDate
            };
            var lstCat = _categories.GetAll().Select(c => new Category_ViewData
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
            ViewData["CategoriesList"] = new SelectList(lstCat, "CategoryID", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Update_Product_VM model)
        {
            var product = _productService.GetById(model.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductId = model.ProductId;
            product.Name = model.Name;
            product.ShortDescription = model.ShortDescription;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.Status = model.Status;
            product.CategoryID = model.CategoryID;
            product.UploadDate = model.UploadDate;

            if (model.Image != null && model.Image.Length > 0)
            {
                var helper = new ConvertImgToString(_webHostEnvironment);
                product.Image = helper.ConvertImg(model.Image,"Sneaker").Result;            
            }
            await _productService.UpdateAsSync(product);
            _notifyService.Success("Cập nhật sản phẩm thành công!");
            return RedirectToAction("Index");
        }
    }
}
