using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebBanHang2._0.Models;
using WebBanHang2._0.Repository;


namespace WebBanHang.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ProductController : Controller
	{
		private readonly DataContext _dataContext;
		public ProductController(DataContext context) 
		{
			_dataContext = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Products.OrderByDescending(p => p.Id).Include(p => p.Category).Include(p => p.Brand).ToListAsync());
		}
        public static string GenerateSlug(string name)
        {
            // Chuyển đổi tất cả chữ cái thành chữ thường
            string slug = name.ToLower();

            // Thay thế khoảng trắng và các ký tự đặc biệt bằng dấu gạch ngang
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');

            return slug;
        }
        [HttpGet]
        public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories,"Id","Name");
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name");
            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductModel product)
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories,"Id","Name",product.CategoryId);
			ViewBag.Brands = new SelectList(_dataContext.Brands,"Id","Name",product.BrandId);
            product.Slug = GenerateSlug(product.Name);
            if (ModelState.IsValid)
			{
				//Them du lieu
				_dataContext.Add(product);
				await _dataContext.SaveChangesAsync();
				TempData["Success"] = "Thanh cong";
			}
			else
			{
				TempData["Error"] = "Co loi dang xay ra, hay kiem tra lai";
				List<string> errors = new List<string>();
				foreach(var value in ModelState.Values)
				{
					foreach(var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string errorMessage = string.Join("\n", errors);
				return BadRequest(errorMessage);
			}
			return View(product);
		}
        public async Task<IActionResult> Edit(int Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
            return View(product);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id,ProductModel product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
            if (ModelState.IsValid)
            {
                //Update du lieu
                _dataContext.Update(product);
                await _dataContext.SaveChangesAsync();
                TempData["Success"] = "Thanh cong";
            }
            else
            {
                TempData["Error"] = "Co loi dang xay ra, hay kiem tra lai";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(product);
        }
        public async Task<IActionResult> Delete(int Id)
		{
            ProductModel product = await _dataContext.Products.FindAsync(Id);
			_dataContext.Remove(product);
			await _dataContext.SaveChangesAsync();
			TempData["Success"] = "Xoa thanh cong";
            return RedirectToAction("Index");
		}
    }
	
}
