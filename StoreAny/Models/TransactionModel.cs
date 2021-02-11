using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAny.Models
{
    public class TransactionModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int MenuCode { get; set; }
        public string IteamName { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
    }
    public enum TransactionType
    {
        sell,
        purchase
    }
   
}