using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_HW_4_Publishers.Models
{
	public class RoleRepository
	{
		static RoleRepository _instance;
		static public RoleRepository Instance => _instance ?? (_instance = new RoleRepository());
		private RoleRepository() { }

		private List<Role> Roles { get; } = new List<Role>() { new Role() { Id = 0, Name = "User" }, new Role() { Id = 1, Name = "Admin" } };
		public Role FindById(int? id) => Roles.Find(i => i.Id == id);
		public void Edit(int id, Role role)
		{
			Roles[Roles.FindIndex(u => u.Id == id)] = role;
		}
		public void Add(Role role)
		{
			role.Id = (Roles.LastOrDefault()?.Id ?? 0) + 1;
			Roles.Add(role);
		}
		public bool Remove(Role role) => Roles.Remove(role);
		public IEnumerable<Role> ToList() => Roles;
	}
}