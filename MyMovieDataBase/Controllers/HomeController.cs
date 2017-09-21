using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMovieDataBase.Services;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using MyMovieDataBase.Methods;

namespace MyMovieDataBase.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			
			//Run once then comment
			Database.CreateDatabase();
			
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
