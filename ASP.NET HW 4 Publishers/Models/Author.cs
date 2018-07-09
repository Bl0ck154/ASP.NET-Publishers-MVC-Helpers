using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class Author
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Date of birth")]
		public DateTime DateOfBirth { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Date of death")]
		public DateTime? DateOfDeath { get; set; }
		public override string ToString() => Name;
	}
}