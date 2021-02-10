using Dapper;
using StoreAny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAny.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var result = DapperORM.ReturnList<CustomerModel>("CustomerViewAll");
            return View(result);
        }


        [HttpPost]
        public ActionResult Index(CustomerModel cust)
        {
            
            var result = DapperORM.ReturnList<CustomerModel>("CustomerViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add(int id=0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CustomerModel cust)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", cust.Id);
            param.Add("@Name", cust.Name);
            param.Add("@SAPCode", cust.SAPCode);
            param.Add("@Address", cust.Address);
            param.Add("@GSTNo", cust.GSTNo);
            param.Add("@Type", cust.type);
            DapperORM.ExecutewithoutReturn("CustomerAdd", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            var result=View(DapperORM.ReturnList<CustomerModel>("CustomerViewById", param).FirstOrDefault<CustomerModel>());
            return (result);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel cust)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", cust.Id);
            param.Add("@Name", cust.Name);
            param.Add("@SAPCode", cust.SAPCode);
            param.Add("@Address", cust.Address);
            param.Add("@GSTNo", cust.GSTNo);
            DapperORM.ExecutewithoutReturn("CustomerEdits", param);
            return RedirectToAction("Index");
        } 
    }
}