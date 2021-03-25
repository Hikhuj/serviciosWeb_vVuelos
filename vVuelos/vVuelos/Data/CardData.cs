using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class CardData
    {
        public int id { get; set; }
        public string card_number { get; set; }
        public int month_expired { get; set; }
        public int year_expired { get; set; }
        public int cvv { get; set; }
        public string issuer { get; set; }
    }
}