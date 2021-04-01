using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

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

        public static List<ConsecutiveData> GetConsecutives()
        {
            using (vVuelosEntities dbLink = new vVuelosEntities())
            {
                return (from a in dbLink.consecutives
                        select new ConsecutiveData
                        {
                            id = a.id,
                            description = a.description,
                            value = a.value,
                            prefix = a.prefix,
                            range_int = a.range_int,
                            range_out = a.range_out
                        }
                        ).ToList();
            }
        }


    }
}