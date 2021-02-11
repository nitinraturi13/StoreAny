using Dapper;
using StoreAny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAny.Controllers
{
    public class Inter_company_PartyController : Controller
    {        
        public ActionResult Index()
        {           
            var result = DapperORM.ReturnList<Inter_Company_PartyModel>("Inter_Company_PartyViewAll");
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(Inter_Company_PartyModel inter)
        {         
            var result = DapperORM.ReturnList<Inter_Company_PartyModel>("Inter_company_PartyViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Inter_Company_PartyModel inter)
        {           
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", inter.Name);
            param.Add("@SAPCode", inter.SAPCode);
            param.Add("@Address", inter.Address);
            DapperORM.ExecutewithoutReturn("Inter_company_partyAdd", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            var result =View(DapperORM.ReturnList<Inter_Company_PartyModel>("Inter_company_partyEdit", param).FirstOrDefault<Inter_Company_PartyModel>());
            return result;
        }

        [HttpPost]
        public ActionResult Edit(Inter_Company_PartyModel inter)
        { 
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", inter.Id);
            param.Add("@Name", inter.Name);
            param.Add("@SAPCode", inter.SAPCode);
            param.Add("@Address", inter.Address);
            DapperORM.ExecutewithoutReturn("Inter_company_partyEdit", param);
            return RedirectToAction("Index");
        }
    }
}