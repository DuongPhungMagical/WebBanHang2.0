using System.ComponentModel.DataAnnotations;

namespace WebBanHang2._0.Models
{
	public class BrandModel
	{
		[Key]
		public int Id { get; set; }
		[Required,MinLength(3,ErrorMessage = "Yêu cầu nhập hãng")]
		public string Name { get; set; }
		[Required, MinLength(3, ErrorMessage = "Yêu cầu nhập mô tả hãng")]
		public string Description { get; set; }
		[Required]
		public string Slug { get; set; }
		public int Status { get; set; }
	}
}
