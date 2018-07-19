using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[MinLength(6)]
		[StringLength(32)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[MinLength(2)]
		public string Name { get; set; }
		[Display(Name = "Role")]
		public int? RoleId { get; set; }
		public override string ToString() => Email + " " + Name;
	}
}