using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string Password { get; set; }
	}
}