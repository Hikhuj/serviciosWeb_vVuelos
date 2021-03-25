using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class UserCardData
    {
        public int user_id_FK { get; set; }
        public int cards_FK { get; set; }
    }
}