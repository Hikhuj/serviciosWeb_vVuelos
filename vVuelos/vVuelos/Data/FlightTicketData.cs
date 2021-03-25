using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class FlightTicketData
    {
        public string consecutivo_flight_ticket_id { get; set; }
        public int user_id { get; set; }
        public string consecutive_country_id_FK { get; set; }
    }
}