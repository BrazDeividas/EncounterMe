﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServer.Controllers
{
    public class ErrorController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody] string value)
        {
            using (StreamWriter writer = new StreamWriter("AppLogs.txt"))
            {
                writer.WriteLine("Error");
                writer.WriteLine(value);
                writer.WriteLine(DateTime.Now);
            }
            return value;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}