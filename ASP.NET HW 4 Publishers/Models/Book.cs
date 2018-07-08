using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class Book
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public Publisher Publisher { get; set; }
		public IEnumerable<Author> Authors { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime PublishDate { get; set; }
		public int PageCount { get; set; }
		public string ISBN { get; set; }
	}
}