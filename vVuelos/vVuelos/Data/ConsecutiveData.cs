using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class ConsecutiveData
    {

        public int id { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public string prefix { get; set; }
        public int? range_int { get; set; }
        public int? range_out { get; set; }

    }
}