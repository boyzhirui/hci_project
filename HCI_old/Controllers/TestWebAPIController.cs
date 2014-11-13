using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class TestWebAPIController : ApiController
    {
        public class Obj
        {
            public int ID{get;set;}
            public string Value{get;set;}
        }
        // GET: api/TestWebAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestWebAPI/5
        public Obj Get(int id)
        {
            return new Obj{ ID = id, Value = "value"};
        }

        // POST: api/TestWebAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestWebAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestWebAPI/5
        public void Delete(int id)
        {
        }
    }
}
