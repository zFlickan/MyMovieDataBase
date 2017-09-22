using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyMovieDataBase.Domain;
using MyMovieDataBase.Services;
using NHibernate.Linq;

namespace MyMovieDataBase.Controllers
{
    [RoutePrefix("Session")]
    public class SessionController : ApiController
    {
        //**************************************************************//
        //						                              LOG IN	//
        [Route("LogIn"), HttpGet]
        public IHttpActionResult LogIn(string userNameInput, string passwordInput)
        {
            var session = DbService.OpenSession();

            var dbUser = session.Query<MmdbUser>().Where(c => c.Username == userNameInput && c.Password == passwordInput).Single();

            string response = "";
            if (userNameInput == dbUser.Username && passwordInput == dbUser.Password)
            {
                response = "Log in successfull!";
            }
            else
            {
                response = "Invalid username or password.";
                return BadRequest(response);
            }

            DbService.CloseSession(session);

            return Ok(response);
        }

        [Route("CreateNewUser"), HttpPost]
        public IHttpActionResult CreateNewUser(MmdbUser newUser)
        {
            var session = DbService.OpenSession();
            string response = "";
            string newUsername = newUser.Username;
            string newPassword = newUser.Password;

            MmdbUser newMmdbUser = new MmdbUser()
            {
                Username = newUsername,
                Password = newPassword
            };
            session.Save(newMmdbUser);

            response = "New user created successfully.";

            DbService.CloseSession(session);

            return Ok(response);

        }
        //***************************************************************//


        //***************************************************************//
        //														LOG OUT  //
        [Route("LogOut")]
        public IHttpActionResult LogOut()
        {

            return Ok();
        }
        //***************************************************************//


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
