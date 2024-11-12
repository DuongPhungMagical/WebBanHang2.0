﻿using System.ComponentModel.DataAnnotations;

namespace WebBanHang2._0.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
		public string Name { get; set; }
		public string Slug { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả sản phẩm")]
		public string Description { get; set; }
		[Required, Range(0,999999, ErrorMessage = "Gía phải nằm từ 0 đến 999999")]
		public decimal Price { get; set; }
		public string Image { get; set; }
		public int BrandId { get; set; }
		public int CategoryId { get; set; }
		public BrandModel Brand { get; set; }
		public CategoryModel Category { get; set; }
	}
}
