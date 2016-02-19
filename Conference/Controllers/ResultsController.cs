using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class ResultsController : Controller
    {

		[ChildActionOnly()]
        public PartialViewResult _Index()
        {
			return PartialView("_Index");

        }
    }
}
