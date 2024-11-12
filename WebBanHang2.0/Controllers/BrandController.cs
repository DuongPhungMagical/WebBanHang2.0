using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebBanHang2._0.Repository;

namespace WebBanHang2._0.Controllers
{
	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index(string Slug = "")
		{
			var brand = _dataContext.Brands.Where(b => b.Slug == Slug).FirstOrDefault();
			if(brand == null) return RedirectToAction("Index");
			var productByBrand = _dataContext.Products.Where(p => p.BrandId == brand.Id);
			return View(await productByBrand.OrderByDescending(p => p.Id).ToListAsync());
		}
	}
}
