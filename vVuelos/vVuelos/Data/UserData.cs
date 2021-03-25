using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Data
{
    public class UserData
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string old_password { get; set; }
        public string new_password { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string second_last_name { get; set; }
        public int rol_id_FK { get; set; }
        public string cards { get; set; }
        public string consecutive_country_id { get; set; }
        public string security_question1 { get; set; }
        public string answer1 { get; set; }
    }
}