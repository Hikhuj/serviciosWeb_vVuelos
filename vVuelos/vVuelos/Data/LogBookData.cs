using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class LogBookData
    {
        public int id { get; set; }
        public int user_id_FK { get; set; }
        public DateTime timestamp { get; set; }
        public int action_id { get; set; }
        public string action_type { get; set; }
        public string description { get; set; }
        public string detail_description { get; set; }
    }
}