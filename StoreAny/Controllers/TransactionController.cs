using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using StoreAny.Models;

namespace StoreAny.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Purchase
        public object Id { get; private set; }

        [HttpGet]
        public ActionResult Index()
        {

            var result = DapperORM.ReturnList<TransactionModel>("PurchaseViewAll");
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(TransactionModel purc)
        {

            var result = DapperORM.ReturnList<TransactionModel>("PurchaseViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(TransactionModel purc)
        {
           DynamicParameters param = new DynamicParameters();
           param.Add("@CustomerId", purc.CustomerId);
           param.Add("@CustomerName", purc.CustomerName);
           param.Add("@SupplierId", purc.SupplierId);
           param.Add("@SupplierName", purc.SupplierName);
           param.Add("@MenuCode", purc.MenuCode);
           param.Add("@ItemName", purc.IteamName);
           param.Add("@Quantity", purc.Quantity);
           DapperORM.ExecutewithoutReturn("PurchaseAdd", param);
            return RedirectToAction("Index");
        }
    }
}
   
