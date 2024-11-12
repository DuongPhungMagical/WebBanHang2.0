using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanHang2._0.Models;
using WebBanHang2._0.Repository;

namespace WebBanHang2._0.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, DataContext dataContext)
		{
			_logger = logger;
			_dataContext = dataContext;
		}

		public IActionResult Index()
		{
			var product = _dataContext.Products.Include("Category").Include("Brand").ToList();
			return View(product);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
