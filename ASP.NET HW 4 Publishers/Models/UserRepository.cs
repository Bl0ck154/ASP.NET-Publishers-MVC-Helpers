using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class UserRepository
	{
		static UserRepository _instance;
		static public UserRepository Instance => _instance ?? (_instance = new UserRepository());
		private UserRepository() { }

		private List<User> Users { get; } = new List<User>();
		public User FindById(int? id) => Users.Find(i => i.Id == id);
		public void Edit(int id, User user)
		{
			Users[Users.FindIndex(u => u.Id == id)] = user;
		}
		public void Add(User user)
		{
			user.Id = (Users.LastOrDefault()?.Id ?? 0) + 1;
			Users.Add(user);
		}
		public bool Remove(User user) => Users.Remove(user);
		public IEnumerable<User> ToList() => Users;
	}
}