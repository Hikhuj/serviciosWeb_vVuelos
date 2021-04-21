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




    public class CreditController : ApiController
    {
        private vVuelos_paymentEntities db = new vVuelos_paymentEntities();

        public int Get() {
            return 1;
        }

        [HttpPost]
        public object Post([FromBody()] CardModel cardM)
        {
            cards card = new cards(cardM.card_number.ToString(),cardM.expiration_month,cardM.expiration_year,cardM.cvv,cardM.issuer);
            int status = VerificacionTarjeta.VerificarTarjetas(card, cardM.monto, db);
            return Request.CreateResponse(HttpStatusCode.OK, new {status}); 
        }

    }
}
