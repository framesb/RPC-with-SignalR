using Conference.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
	[HandleError(ExceptionType = typeof(SqlException), View = "_SqlException")]
	[HandleError(View = "_GenericException")]
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
				return View("Index");
			
		}
	}
}
