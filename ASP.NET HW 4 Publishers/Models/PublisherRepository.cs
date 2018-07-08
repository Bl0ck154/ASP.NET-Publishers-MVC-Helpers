using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
    public class PublisherRepository
	{
		static PublisherRepository _instance;
		static public PublisherRepository Instance => _instance ?? (_instance = new PublisherRepository());
		private PublisherRepository() { }

		private List<Publisher> Publishers { get; } = new List<Publisher>() { new Publisher() { Id = 0, Name = "Bloomsbury Publishing" } };
		public Publisher FindById(int? id) => Publishers.Find(i => i.Id == id);
		public void Edit(int id, Publisher publisher)
		{
			Publishers[Publishers.FindIndex(u => u.Id == id)] = publisher;
		}
		public void Add(Publisher publisher)
		{
			publisher.Id = (Publishers.LastOrDefault()?.Id ?? 0) + 1;
			Publishers.Add(publisher);
		}
		public bool Remove(Publisher publisher) => Publishers.Remove(publisher);
		public IEnumerable<Publisher> ToList() => Publishers;
		public Publisher FindByName(string name) => Publishers.Find(i => i.Name == name);
	}
}
