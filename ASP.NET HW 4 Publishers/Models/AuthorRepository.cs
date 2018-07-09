﻿using System;
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
			new Author() { Id = 0, Name = "Joanne Rowling", DateOfBirth = new DateTime(1965, 07, 31) },
			new Author() { Id = 1, Name = "Александр Пушкин", DateOfBirth = new DateTime(1799, 06, 06), DateOfDeath = new DateTime(1837, 02, 10) } };
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
