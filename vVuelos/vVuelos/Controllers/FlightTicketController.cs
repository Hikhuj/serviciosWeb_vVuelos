using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace vVuelos.Controllers
{
    public class FlightTicketController : ApiController
    {
        // GET: api/FlightTicket
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightTicket/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FlightTicket
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FlightTicket/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlightTicket/5
        public void Delete(int id)
        {
        }
    }
}
