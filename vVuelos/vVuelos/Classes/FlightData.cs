using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vVuelos.Classes
{
    public class FlightData
    {
        public string consecutive_flight_id { get; set; }
        public string code { get; set; }
        public string consecutive_airline_id { get; set; }
        public int city_id { get; set; }
        public DateTime arrival_date { get; set; }
        public DateTime arrival_time { get; set; }
        public string consecutive_airport_gate_id_FK { get; set; }
        public Boolean status { get; set; }
    }
}