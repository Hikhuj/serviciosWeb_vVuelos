using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vVuelos.Classes
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