using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebBanHang2._0.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }
		[Required,MinLength(4,ErrorMessage ="Yêu cầu nhập danh mục")]
		public string Name { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả danh mục")]
		public string Description { get; set; }
		[Required]
		public string Slug { get; set; }
		public int Status { get; set; }
	}
}
