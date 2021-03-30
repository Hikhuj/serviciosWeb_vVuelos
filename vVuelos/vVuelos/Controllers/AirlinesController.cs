using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace vVuelos.Controllers
{
    public class AirlinesController : ApiController
    {
        // GET: api/Airlines
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Airlines/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Airlines
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Airlines/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Airlines/5
        public void Delete(int id)
        {
        }
    }
}
