﻿using System;
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
        // Retorna una estructura de datos
        // COLLECTIONS
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EasyPay/5
        // Retorna un dato especifico dado un X numero
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EasyPay
        public void Post([FromBody]string value)
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
