using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieDataBase.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}

		public ActionResult MyMovies()
		{
			ViewBag.Title = "My Movies";

			return View();
		}

		public ActionResult HandleAccount()
		{
			ViewBag.Title = "Handle Account";

			return View();
		}
	}
}
