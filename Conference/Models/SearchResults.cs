using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Models
{
	public class SearchResults
	{

		public int Total { get; set; }

		public int Processed { get; set; }

		public virtual List<Product> Results { get; set; }
	}
}