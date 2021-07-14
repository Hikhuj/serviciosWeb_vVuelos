using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BancoAPI.Logic
{
    public class VerificacionTarjeta
    {
        //Recibir los datos
        //Checkear informacion en db
        //Llamar transaccion 
        public static int VerificarTarjetas(cards card,decimal monto, vVuelos_paymentEntities db) {
            cards currentCard = db.cards.Where(c => c.card_number == card.card_number).FirstOrDefault();
            if (currentCard != null)
            {
                //Check expiration
                if (card.expiration_month == currentCard.expiration_month
                    && card.expiration_year >= DateTime.UtcNow.Year
                    && card.expiration_month >= DateTime.UtcNow.Month)
                {
                    //Check CVV information
                    if (card.cvv == currentCard.cvv)
                    {
                        //Check if is debit or credit
                        if (currentCard.is_debit_card)
                        {
                            //Check account has funds
                            if (monto <= currentCard.balance)
                            {
                                //Make payment
                                currentCard.balance = currentCard.balance - monto;
                                db.Entry(currentCard).State = EntityState.Modified;
                                db.SaveChanges();
                                return 0;
                            }
                            else { return -4; }
                        }
                        else {
                            //Check card limit
                            if (currentCard.credit_limit < (currentCard.balance + monto))
                            {
                                currentCard.balance = currentCard.balance + monto;
                                return 0;
                            }
                            else { return -4; }
                        }
                    }
                    else { return -3; }
                    
                }
                else { return -2; }

            }
            else { return -1; } 
        }

    }
}