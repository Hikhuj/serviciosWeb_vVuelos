using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vVuelos.Classes
{
    public class TransactionData
    {
        public string consecutive_transaction_id { get; set; }
        public DateTime transaction_date { get; set; }
        public string payment_method { get; set; }
        public int amount { get; set; }
    }
}