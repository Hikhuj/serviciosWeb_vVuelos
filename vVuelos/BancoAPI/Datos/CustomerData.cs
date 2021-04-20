using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using BancoAPI.Models;

namespace BancoAPI.Datos
{
    public class CustomerData
    {
        public int user_id { get; set; }
        public int easy_pay_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }

        // Customer Collections
        public static List<CustomerData> getListCustomerData()
        {
            using (vVuelos_paymentEntities db = new vVuelos_paymentEntities())
            {
                return (from item in db.customer
                        select new CustomerData
                        {
                            user_id = item.user_id,
                            easy_pay_id = item.easy_pay_id,
                            name = item.name,
                            last_name = item.last_name
                        }).ToList();
            }
        }

    }
}