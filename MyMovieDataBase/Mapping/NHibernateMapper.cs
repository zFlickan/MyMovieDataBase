using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMovieDataBase.Domain;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace MyMovieDataBase.Mapping
{
	public class NHibernateMapper
	{

		private readonly ModelMapper _modelMapper;

		public NHibernateMapper()
		{
			_modelMapper = new ModelMapper();
		}

		public HbmMapping Map()
		{
			MapMovie();
			MapGenre();
            MapUser();
			return _modelMapper.CompileMappingForAllExplicitlyAddedEntities();
		}

		private void MapMovie()
		{
			_modelMapper.Class<Movie>(e =>
			{
				e.Id(p => p.MovieID, p => p.Generator(Generators.GuidComb));
				e.Property(p => p.Title);
				e.Property(p => p.Year);
				e.Property(p => p.Rating);
				e.Property(p => p.Link);

				e.Set(x => x.Genres, collectionMapping =>
				{
					collectionMapping.Inverse(true);
					// Ange namn på den mellanliggande tabellen
					collectionMapping.Table("MovieGenres");

					// Sätt alltid "Cascade.None" vid en många-till-många-relation
					collectionMapping.Cascade(Cascade.None);

					// Här anger du tabellens kolumn-namn
					collectionMapping.Key(keyMap => keyMap.Column("MovieID"));
				}, map => map.ManyToMany(p => p.Column("GenreID")));
			});

		}

		private void MapGenre()
		{
			_modelMapper.Class<Genre>(e =>
			{
				e.Id(p => p.GenreID, p => p.Generator(Generators.Increment));
				e.Property(p => p.GenreName);

				e.Set(x => x.Movies, collectionMapping =>
				{
					//collectionMapping.Inverse(true);
					// Ange namn på den mellanliggande tabellen
					collectionMapping.Table("MovieGenres");

					// Sätt alltid "Cascade.None" vid en många-till-många-relation
					collectionMapping.Cascade(Cascade.None);

					// Här anger du tabellens kolumn-namn
					collectionMapping.Key(keyMap => keyMap.Column("GenreID"));
				}, map => map.ManyToMany(p => p.Column("MovieID")));
			});

		}
        private void MapUser()
        {
            _modelMapper.Class<User>(e =>
            {
                e.Table("[User]");  
                e.Id(p => p.UserID, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Username);
                e.Property(p => p.Password);


                //e.Set(x => x.Movies, collectionMapping =>
                //{
                //    collectionMapping.Inverse(true);
                //    // Ange namn på den mellanliggande tabellen
                //    collectionMapping.Table("UserMovies");

                //    // Sätt alltid "Cascade.None" vid en många-till-många-relation
                //    collectionMapping.Cascade(Cascade.None);

                //    // Här anger du tabellens kolumn-namn
                //    collectionMapping.Key(keyMap => keyMap.Column("UserID"));
                //}, map => map.ManyToMany(p => p.Column("MovieID")));
            });

        }
    }
}