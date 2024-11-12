using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang2._0.Repository;

namespace WebBanHang2._0.Controllers
{
	public class ProductController : Controller
	{
		private readonly DataContext _dataContext;
		public ProductController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Details(int Id)
		{
			var product = _dataContext.Products.Include("Category").Include("Brand").FirstOrDefault(p => p.Id == Id);
			if (product == null) return RedirectToAction("Index");
			return View(product);
		}
	}
}
