using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Conference
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("WebServices/*");

			// Session/1
			// Route to the details page
			routes.MapRoute(
				name: "DetailsRoute",
				url: "{controller}/{id}",
				defaults: new { action = "Details" },
				constraints: new { id = "[0-9]+" });

			// Session/Edit/1
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}