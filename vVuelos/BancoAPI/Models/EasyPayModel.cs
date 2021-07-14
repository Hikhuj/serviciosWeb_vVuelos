using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class EasyPayModel
    {
        public EasyPayModel() { }

        public EasyPayModel(int num_cuenta, int cod_seg, string password, double monto)
        {
            this.num_cuenta = num_cuenta;
            this.cod_seg = cod_seg;
            this.password = password;
            this.monto = monto;
        }

        public int num_cuenta { get; set; }
        public int cod_seg { get; set; }
        public string password { get; set; }
        public double monto { get; set; }
    }
}