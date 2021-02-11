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
            var result = DapperORM.ReturnList<TransactionModel>("TransactionsViewAll");
            return View(result);  
        }
        [HttpPost]
        public ActionResult Index(TransactionModel purc)
        {
            var result = DapperORM.ReturnList<TransactionModel>("TransactionsViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var list1 = new List<int>() { 5, 6, 7 };
            ViewBag.list1 = list1;
            var list2 = new List<String>() {"sachin" ,"nitin","narendra" };
            ViewBag.list2 = list2;
            var list3 = new List<int>() { 8,9,10 };
            ViewBag.list3 = list3;
            var list4 = new List<string>() { "ram","shyam","deepak" };
            ViewBag.list4 = list4;
            var list5 = new List<int>() { 7, 8, 9, 10 };
            ViewBag.list5 = list5;
            var list6 = new List<string>() { "toothpaste", "syrup", "soap", "chocolate" };
            ViewBag.list6 = list6;
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
            param.Add("@Type", purc.Type);
            DapperORM.ExecutewithoutReturn("TransactionsAdd", param);
            return RedirectToAction("Index");
        }
    }
}
   
