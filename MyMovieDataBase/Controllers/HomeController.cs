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
using MyMovieDataBase.Domain;

namespace MyMovieDataBase.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			//Run once then comment
			//Database.CreateDatabase();
			return View();
			
		}

		[HttpGet]
		public ActionResult MyMovies(string username)
		{
			ViewBag.Title = "My Movies";

			var session = DbService.OpenSession();
			var dbUser = session.Query<MmdbUser>().Where(c => c.Username == username).Single();
			if (username == dbUser.Username)
			{
				Session["UserID"] = dbUser.UserID;
			}
			DbService.CloseSession(session);

			var model = Read.ReadAll();
			//var model = Read.ReadAll(dbUser.UserID);

			return View(model);
		}

		public ActionResult HandleAccount()
		{
			ViewBag.Title = "Handle Account";

			return View();
		}
	}
}
