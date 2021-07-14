using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BancoAPI.Logic
{
    public class VerificacionEasyPay
    {
        public static int VerificarEasyPay(EasyPayModel account, vVuelos_paymentEntities db) {
            //Check account info
            easy_pay currentAccount = db.easy_pay.Find(account.num_cuenta);
            if (currentAccount != null)
            {
                //Check sec code
                if (currentAccount.security_code.Equals(account.cod_seg))
                {
                    //Check password
                    if (currentAccount.password.Equals(account.password))
                    {
                        if (currentAccount.current_amount <= account.monto)
                        {
                            currentAccount.current_amount = currentAccount.current_amount - account.monto;
                            db.Entry(currentAccount).State = EntityState.Modified;
                            db.SaveChanges();
                            return 0;
                        }
                        else { return -4; }
                    }
                    else { return -3; }
                }
                else { return -2; }
            }
            else { return -1; }
        }
    }
}