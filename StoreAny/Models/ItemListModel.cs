using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAny.Models
{
    public class ItemListModel
    {
     public int Id { get; set; }

     public string MenuCode { get; set; }

     public string ItemName { get; set; }
     public DateTime UpdateTime { get; set; }
    }
}