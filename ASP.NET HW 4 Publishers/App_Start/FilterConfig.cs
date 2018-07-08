using System.Web;
using System.Web.Mvc;

namespace ASP.NET_HW_4_Publishers
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
