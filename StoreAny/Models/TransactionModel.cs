using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAny.Models
{
    public class TransactionModel
    {
        public List<int> CustomerId { get; set; }
        public List<string> CustomerName { get; set; }
        public List<int> SupplierId { get; set; }
        public List<int> supplierName { get; set; }
        public object SupplierName { get; internal set; }
        public List<int> MenuCode { get; set; }
        public List<string> IteamName { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public DefineType Define { get; set; }
    }
    public enum TransactionType
    {
        sell,
        purchase
    }
    public enum DefineType
    {
        c,
        s
    }
}