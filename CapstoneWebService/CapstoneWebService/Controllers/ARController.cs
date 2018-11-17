using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneWebService.Controllers
{
    public class ARController : ApiController
    {
        // GET: api/AR
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AR
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AR/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AR/5
        public void Delete(int id)
        {
        }
    }
}
