using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class CityData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string consecutive_country_id_FK { get; set; }

    }
}