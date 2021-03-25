using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class ErrorData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime timestamp { get; set; }
    }
}