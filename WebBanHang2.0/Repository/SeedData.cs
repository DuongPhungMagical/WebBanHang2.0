using Microsoft.EntityFrameworkCore;
using WebBanHang2._0.Models;

namespace WebBanHang2._0.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if (!_context.Products.Any())
			{
				CategoryModel macbook = new CategoryModel { Name = "Macbook", Slug = "Macbook", Description = "Macbook is the second", Status = 1 };
				CategoryModel Laptop = new CategoryModel { Name = "Laptop", Slug = "Laptop", Description = "Laptop is the best", Status = 2 };
				BrandModel apple = new BrandModel { Name = "Apple", Slug = "Apple", Description = "Apple is the second", Status = 1 };
				BrandModel lenovo = new BrandModel { Name = "Lenovo", Slug = "Lenovo", Description = "Lenovo is the best", Status = 2 };
				_context.Products.AddRange(
					new ProductModel { Name = "Macbook", Price = 5000, Slug = "Macbook", Description="Macbook is the second", Image = "1.jpg", Category = macbook, Brand = apple },
					new ProductModel { Name = "Lenovo z1000", Price = 3000, Slug = "LenovoZ1000", Description = "LenovoZ1000 is the best", Image = "2.jpg", Category = Laptop, Brand = lenovo }
				);
			}
			_context.SaveChanges();
		}
	}
}
