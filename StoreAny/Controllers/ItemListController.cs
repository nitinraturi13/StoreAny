using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using StoreAny.Models;

namespace StoreAny.Controllers
{
    public class ItemListController : Controller
    {
        public object Id { get; private set; }

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            
            var result = DapperORM.ReturnList<ItemListModel>("Item_listViewAll");
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(ItemListModel item)
        {
            
            var result = DapperORM.ReturnList<ItemListModel>("Item_listViewById");
            return View(result);
        }
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ItemListModel item)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", item.Id);
            param.Add("@MenuCode", item.MenuCode);
            param.Add("@ItemName", item.ItemName);
            param.Add("@UpdateTime", item.UpdateTime);          
            DapperORM.ExecutewithoutReturn("Item_listAdd", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            var result = View(DapperORM.ReturnList<ItemListModel>("Item_listViewById", param).FirstOrDefault<ItemListModel>());
            return (result);
        }

        [HttpPost]
        public ActionResult Edit(ItemListModel item)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", item.Id);
            param.Add("@MenuCode", item.MenuCode);
            param.Add("@ItemName", item.ItemName);
            param.Add("@UpdateTime", item.UpdateTime);
            DapperORM.ExecutewithoutReturn("Item_listEdit",param);
            return RedirectToAction("Index");
        }
    }
}