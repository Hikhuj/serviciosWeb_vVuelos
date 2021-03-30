using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace vVuelos.Controllers
{
    public class ReservationsController : ApiController
    {
        // GET: api/Reservations
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reservations/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservations
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reservations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
        }
    }
}
