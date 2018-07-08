using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
    public class AuthorRepository
	{
		static AuthorRepository _instance;
		static public AuthorRepository Instance => _instance ?? (_instance = new AuthorRepository());
		private AuthorRepository() { }

		private List<Author> Authors { get; } = new List<Author>() {
			new Author() { Id = 1, Name = "Pushkin", DateOfBirth = DateTime.Now },
			new Author() { Id = 2, Name = "Turgenev", DateOfBirth = DateTime.Now } };
		public Author FindById(int? id) => Authors.Find(i => i.Id == id);
		public void Edit(int id, Author author)
		{
			Authors[Authors.FindIndex(u => u.Id == id)] = author;
		}
		public void Add(Author author)
		{
			author.Id = (Authors.LastOrDefault()?.Id ?? 0) + 1;
			Authors.Add(author);
		}
		public bool Remove(Author author) => Authors.Remove(author);
		public IEnumerable<Author> ToList() => Authors;
		public Author FindByName(string name) => Authors.Find(i => i.Name == name);
	}
}
