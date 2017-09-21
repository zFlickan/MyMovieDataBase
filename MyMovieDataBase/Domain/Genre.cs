using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieDataBase.Domain
{
	public class Genre
	{
		public Genre()
		{
			Movies = new List<Movie>();
		}
		public virtual int GenreID { get; set; }
		public virtual string GenreName { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}

	enum Genres
	{
		Action, Horror, Love, Drama, Biography, Thriller, War
	}
}