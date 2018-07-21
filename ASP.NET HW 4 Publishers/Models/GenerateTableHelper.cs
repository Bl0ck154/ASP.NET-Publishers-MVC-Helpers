using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HW_4_Publishers.Models
{
	public static class GenerateTableHelper
	{
		public static MvcHtmlString GenerateSimpleTable<T>(this HtmlHelper htmlHelper, IEnumerable<T> db)
		{
			TagBuilder table = new TagBuilder("table");
			table.AddCssClass("table");

			int counter = 0;
			foreach (T item in db)
			{
				TagBuilder tr = new TagBuilder("tr");
				foreach (var propInfo in typeof(T).GetProperties().Where(pr => pr.Name.ToLower() == "name"))
				{
					tr.InnerHtml += new TagBuilder("td") { InnerHtml = (++counter).ToString() };
					tr.InnerHtml += new TagBuilder("td") { InnerHtml = propInfo.GetValue(item).ToString() };
				}
				table.InnerHtml += tr.ToString();
			}

			return new MvcHtmlString(table.ToString());
		}

		public static MvcHtmlString GenerateTable<T>(this HtmlHelper htmlHelper, IEnumerable<T> db, Func<T, string> additionalColumn = null)
		{
			TagBuilder table = new TagBuilder("table");
			table.AddCssClass("table");

			TagBuilder tr = new TagBuilder("tr");

			foreach (PropertyInfo propInfo in typeof(T).GetProperties())
			{
				if (propInfo.GetCustomAttribute<ScaffoldColumnAttribute>()?.Scaffold == true)
					continue;
				tr.InnerHtml += new TagBuilder("th") { InnerHtml = propInfo.GetCustomAttribute<DisplayAttribute>()?.Name ?? propInfo.Name }.ToString();
			}

			if (additionalColumn != null)
				tr.InnerHtml += new TagBuilder("th").ToString();

			table.InnerHtml += tr.ToString();

			foreach (T item in db)
			{
				tr = new TagBuilder("tr");
				foreach (PropertyInfo propInfo in typeof(T).GetProperties())
				{
					if (propInfo.GetCustomAttribute<ScaffoldColumnAttribute>()?.Scaffold == true)
						continue;
					else if (propInfo.GetCustomAttribute<DataTypeAttribute>()?.DataType == DataType.Password)
						tr.InnerHtml += new TagBuilder("td") { InnerHtml = new string('*', propInfo.GetValue(item).ToString().Length) };
					else
						tr.InnerHtml += new TagBuilder("td")
						{
							InnerHtml = propInfo.Name == "RoleId" ?
								RoleRepository.Instance.FindById((int?)propInfo.GetValue(item))?.Name
								: propInfo.GetValue(item)?.ToString()
						}.ToString();
				}
				if (additionalColumn != null)
					tr.InnerHtml += new TagBuilder("td") { InnerHtml = additionalColumn(item) }.ToString();

				table.InnerHtml += tr.ToString();
			}

			return new MvcHtmlString(table.ToString());
		}
	}
}