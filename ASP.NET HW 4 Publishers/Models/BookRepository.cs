using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class BookRepository
	{
		static BookRepository _instance;
		static public BookRepository Instance => _instance ?? (_instance = new BookRepository());
		private BookRepository() { }

		private List<Book> Books { get; } = new List<Book>();
		public Book FindById(int? id) => Books.Find(i => i.Id == id);
		public void Edit(int id, Book book)
		{
			Books[Books.FindIndex(u => u.Id == id)] = book;
		}
		public void Add(Book book)
		{
			book.Id = (Books.LastOrDefault()?.Id ?? 0) + 1;
			Books.Add(book);
		}
		public bool Remove(Book book) => Books.Remove(book);
		public IEnumerable<Book> ToList() => Books;
	}
}
