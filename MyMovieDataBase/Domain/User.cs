using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MyMovieDataBase.Domain
{
    class User
    {
        //public User()
        //{
        //Movies = new List<Movie>();
        //}

        public virtual Guid UserID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }
    }
}