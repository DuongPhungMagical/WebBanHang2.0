using Microsoft.AspNetCore.Identity;

namespace WebBanHang2._0.Models
{
	public class AppUserModel : IdentityUser
	{
		public string Occupation { get; set; }
	}
}
