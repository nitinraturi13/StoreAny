using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using StoreAny.Models;

namespace StoreAny.Controllers
{

    public class TransportController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            var result = DapperORM.ReturnList<TransportInfoModel>("Transport_infoViewAll");
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(TransportInfoModel trans)
        {
           
            var result = DapperORM.ReturnList<TransportInfoModel>("Transport_infoViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TransportInfoModel trans)
        {           
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", trans.Id);
            param.Add("@Name", trans.Name);
            param.Add("@Address", trans.Address);
            param.Add("@Email", trans.Email);
            param.Add("@Phone", trans.Phone);
            param.Add("@PAN", trans.PAN);
            DapperORM.ExecutewithoutReturn("Transport_infoAdd", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            var result = View(DapperORM.ReturnList<TransportInfoModel>("Transport_infoViewById", param).FirstOrDefault<TransportInfoModel>());
            return (result);
        }

        [HttpPost]
        public ActionResult Edit(TransportInfoModel trans)
        {            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id",trans.Id);
            param.Add("@Name", trans.Name);
            param.Add("@Address", trans.Address);
            param.Add("@Email", trans.Email);
            param.Add("@Phone", trans.Phone);
            param.Add("@PAN", trans.PAN);
            DapperORM.ExecutewithoutReturn("Transport_infoEdit", param);
            return RedirectToAction("Index");
        }
    }
}