using DevExpress.Web.Mvc;
using Inv.DAL;
using Inv.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Inv.Areas.POS.Controllers
{
    public class PosController : Controller
    {

        private InvContext db = new InvContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsGridViewCallback(string searchString)
        {
            ViewBag.searchString = searchString;
            return PartialView("_ProductsGridViewCallbackPartial");
        }

        public ActionResult ProductsGridView(string searchString){

            var products = from p in db.Products select p;
            if (!String.IsNullOrEmpty(searchString)) {
                products = products.Where(q => q.ProductName.Contains(searchString));
            }
            return PartialView("_ProductsGridViewPartial", products);
        }

        //public JsonResult SaveOrders(List<js> searchString)
        //{
        //    ViewBag.searchString = searchString;

        //    return Json("_ProductsGridViewCallbackPartial");
        //}
        [HttpGet]
        public JsonResult TransactionCreate() {
            
            Transaction transaction = new Transaction() {
                DateCreated = DateTime.Now,
                Status = false
            };

            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                var last_id = db.Transactions.Max(q => q.TransactionID);
                return Json(new { last_inserted_id = last_id}, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { last_inserted_id = "Error on creating transaction"}, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        public JsonResult CheckoutProducts(List<JObject> json) {
            //JObject jsonObject = new JObject(json);
            //object model = json.AsQueryable().Reverse().TakeWhile(q => q.OrderID == null);

            //db.Orders.AddRange(json);
            //db.SaveChanges();


            return Json(new { result =  "success"}, JsonRequestBehavior.AllowGet); ;
        }


    }
}