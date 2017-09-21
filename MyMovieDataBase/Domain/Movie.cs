using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieDataBase.Domain
{
	class Movie
	{
		public Movie()
		{
			Genres = new List<Genre>();
		}
		public virtual Guid MovieID { get; set; }
		public virtual string Title { get; set; }

		public virtual int Year { get; set; }
		//public virtual int seenID { get; set; }
		public virtual string Rating { get; set; }
		public virtual string Link { get; set; }

		public virtual ICollection<Genre> Genres { get; set; }

		//public string genres
		//{
		//	get
		//	{
		//		string sql = $"Select Genres.GenreName from Genres where GenreID={genreID};";
		//		return ReadFromDatabase.OpenSQLstatement(sql);
		//	}

		//}

		//public string seen
		//{
		//	get
		//	{
		//		string sql = $"Select Seen.SeenVal from Seen where SeenID={seenID};";
		//		return ReadFromDatabase.OpenSQLstatement(sql);
		//	}
		//}

		//Constructor
		//public Movie(string inputTitle, int inputYear, int inputGenre, int inputSeen, string inputRating, string inputLink)
		//{
		//	this.title = inputTitle;
		//	this.year = inputYear;
		//	this.genreID = inputGenre;
		//	this.seenID = inputSeen;
		//	this.rating = inputRating;
		//	this.link = inputLink;
		//}

		//Empty Constructor
		//public Movie()
		//{

		//}
	}
}