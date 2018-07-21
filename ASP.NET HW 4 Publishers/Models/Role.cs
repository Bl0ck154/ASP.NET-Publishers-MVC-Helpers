using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class Role
	{
		[ScaffoldColumn(true)]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public override string ToString() => Name;
	}
}