using BancoAPI.Logic;
using BancoAPI.Models;
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
        private vVuelos_paymentEntities db = new vVuelos_paymentEntities();
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
        public object Post([FromBody] EasyPayModel account)
        {
            int status = VerificacionEasyPay.VerificarEasyPay(account,db);
            return Request.CreateResponse(HttpStatusCode.OK, new { status });
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
