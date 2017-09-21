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
    public class Database
    {
        internal static void CreateDatabase()
        {
            var session = DbService.OpenSession();

            DropAndCreateDB();
            FillGenreTable(session);
            FillMovieTable(session);
            FillUserTable(session);

            DbService.CloseSession(session);
        }

        static void DropAndCreateDB()
        {
            //Get the configurationpath
            var config = DbService.Configure();

            var export = new SchemaExport(config);
            export.Drop(false, true);
            export.Create(true, true);
        }

        private static void FillGenreTable(ISession session)
        {
            var listOfGenres = Enum.GetValues(typeof(Genres)).Cast<Genres>();
            foreach (var item in listOfGenres)
            {
                Genre addGenre = new Genre
                {
                    GenreName = item.ToString()
                };
                session.Save(addGenre);
            }
        }

        private static void FillMovieTable(ISession session)
        {
            var horror = session.Query<Genre>().Where(c => c.GenreName == "Horror").Single();
            var war = session.Query<Genre>().Where(c => c.GenreName == "War").Single();
            var action = session.Query<Genre>().Where(c => c.GenreName == "Action").Single();
            var biography = session.Query<Genre>().Where(c => c.GenreName == "Biography").Single();
            var drama = session.Query<Genre>().Where(c => c.GenreName == "Drama").Single();

            Movie ApocalypseNow = new Movie
            {
                Title = "Apocalypse	Now",
                Year = 1978,
                Rating = "8,5",
                Link = "http://www.imdb.com/title/tt0078788/?ref_=fn_al_tt_1"
            };

            //Add genres to movie
            ApocalypseNow.Genres.Add(horror);
            ApocalypseNow.Genres.Add(war);
            //Add movie to genres
            horror.Movies.Add(ApocalypseNow);
            war.Movies.Add(ApocalypseNow);

            Movie Tombstone = new Movie
            {
                Title = "Tombstone",
                Year = 1993,
                Rating = "7,8",
                Link = "http://www.imdb.com/title/tt0108358/?ref_=nv_sr_1"
            };

            //Add genres to movie
            Tombstone.Genres.Add(action);
            Tombstone.Genres.Add(drama);
            Tombstone.Genres.Add(biography);
            //Add movie to genres
            action.Movies.Add(Tombstone);
            drama.Movies.Add(Tombstone);
            biography.Movies.Add(Tombstone);

            //Save Movies
            session.Save(ApocalypseNow);
            session.Save(Tombstone);
            //Saves Genres
            session.Save(action);
            session.Save(biography);
            session.Save(horror);
            session.Save(war);
            session.Save(drama);
        }

        private static void FillUserTable(ISession session)
        {
            

            MmdbUser Frida = new MmdbUser()
            {
                Username = "frida@frida.se",
                Password = "apa"
            };

            MmdbUser Lena = new MmdbUser()
            {
                Username = "lena.fridlund@hotmail.com",
                Password = "kobajs"
            };
            session.Save(Frida);
            session.Save(Lena);
        }
    }
}
