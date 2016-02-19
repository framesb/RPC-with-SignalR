using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace Conference
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//filters.Add(new RequireHttpsAttribute());
			filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(SqlException), View = "_SqlException" });
			filters.Add(new HandleErrorAttribute());
		}
	}
}