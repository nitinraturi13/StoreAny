using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAny.Models
{
    public class TransportInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string PAN { get; set; }
    }
}