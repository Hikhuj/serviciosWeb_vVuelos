using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class EasyPayController : ApiController
    {
        // GET: api/EasyPay
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EasyPay/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EasyPay
        public void Post([FromBody]string num_cuenta, int cod_seg, string password)
        {
            
        }

        // PUT: api/EasyPay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EasyPay/5
        public void Delete(int id)
        {
        }
    }
}
