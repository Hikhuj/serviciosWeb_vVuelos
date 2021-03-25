using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class ReservationData
    {
        public string consecutive_reserve_id { get; set; }
        public int user_id { get; set; }
        public string booking_id { get; set; }
        public int amount { get; set; }
        public int total { get; set; }
        public DateTime alert { get; set; }
    }
}