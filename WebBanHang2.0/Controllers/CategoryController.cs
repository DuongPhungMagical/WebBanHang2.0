using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang2._0.Repository;

namespace WebBanHang2._0.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index(string Slug = "")
		{
			var category = _dataContext.Categories.Where(x =>  x.Slug == Slug).FirstOrDefault();
			if(category == null) return RedirectToAction("Index");
			var productByCategory = _dataContext.Products.Where(x => x.CategoryId == category.Id);
			return View(await productByCategory.OrderByDescending(c => c.Id).ToListAsync());
		}
	}
}
