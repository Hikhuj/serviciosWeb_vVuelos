using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vVuelos.Classes;

namespace vVuelos.Controllers
{
    public class ConsecutivesController : ApiController
    {

        // DESDE UN API NO SE ACCEDE a la DATA

        // GET: api/Consecutives
        public List<ConsecutiveData> Get()
        {
            return ConsecutiveData.GetConsecutives();
        }

        // GET: api/Consecutives/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Consecutives
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Consecutives/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Consecutives/5
        public void Delete(int id)
        {
        }
    }
}
