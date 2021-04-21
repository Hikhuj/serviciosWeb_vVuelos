using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class CardModel
    {
        public CardModel() { }
        public CardModel(string card_number, int expiration_month, int expiration_year, int cvv, string issuer)
        {
            this.card_number = card_number;
            this.expiration_month = expiration_month;
            this.expiration_year = expiration_year;
            this.cvv = cvv;
            this.issuer = issuer;

        }

        public CardModel(string card_number, int expiration_month, int expiration_year, int cvv, string issuer, decimal monto)
        {
            this.card_number = card_number;
            this.expiration_month = expiration_month;
            this.expiration_year = expiration_year;
            this.cvv = cvv;
            this.issuer = issuer;
            this.monto = monto;
        }

        public string card_number { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public int cvv { get; set; }
        public string issuer { get; set; }
        public decimal monto { get; set; }
    }
}