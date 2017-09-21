using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieDataBase
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }       

    }
}