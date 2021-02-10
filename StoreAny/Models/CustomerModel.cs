using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreAny.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SAPCode { get; set; }
        public string Address { get; set; }
        public string GSTNo { get; set; }
        public CustomerType type { get; set; }
    }
    public enum CustomerType
    {
        c,
        s
    }

}