using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using MyMovieDataBase.Domain;
using MyMovieDataBase.Services;

namespace MyMovieDataBase.Methods
{
	public class Read
	{
		internal static List<Movie> ReadAll()
		{
			var session = DbService.OpenSession();
			var allMovies = session.Query<Movie>().ToList();
			DbService.CloseSession(session);
			return allMovies;
		}
	}
}