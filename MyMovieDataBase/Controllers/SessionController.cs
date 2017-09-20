using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MyMovieDataBase.Controllers
{
	[RoutePrefix("Session")]
	public class SessionController : ApiController
	{
		//**************************************************************//
		//						                              LOG IN	//
		[Route("LogIn"), HttpGet]
		public IHttpActionResult LogIn(string userName)
		{
			string respons = "";
			if (userName == "frida")
			{
				respons = "Log in successfull!";
			}
			else
			{
				respons = "Log in failed...";
				return BadRequest(respons);
			}

			return Ok(respons);
		}
		//***************************************************************//


		//******************************//
		//					   LOG OUT  //
		[Route("LogOut")]
		public IHttpActionResult LogOut()
		{

			return Ok();
		}
		//******************************//


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
