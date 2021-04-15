using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    public class ConsecutiveAPIController : ApiController
    {
        private vVuelosEntities db = new vVuelosEntities();
        // GET: api/Consecutives
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Consecutives/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Consecutives
        public object Post([FromBody] consecutive consecutive)
        {
            if (ModelState.IsValid)
            {
                db.sp_create_consecutive(consecutive.description, consecutive.value, consecutive.prefix, consecutive.range_int, consecutive.range_out);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    consecutive = consecutive
                });
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, new { consecutive = "" });
            
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
