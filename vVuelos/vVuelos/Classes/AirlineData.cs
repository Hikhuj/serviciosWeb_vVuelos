using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vVuelos.Classes
{
    public class AirlineData
    {
        public string consecutive_airline_id { get; set; }
        public string name { get; set; }
        public string consecutive_country_id_FK { get; set; }
        public string image { get; set; }
    }
}