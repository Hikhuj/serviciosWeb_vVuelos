using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class AirportGateData
    {
        public string consecutive_airport_gate_id { get; set; }
        public int number { get; set; }
        public Boolean status { get; set; }
    }
}