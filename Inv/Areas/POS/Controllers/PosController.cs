using DevExpress.Web.Mvc;
using Inv.Entities;
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

        private InvEntities db = new InvEntities();

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
            return Json(new { result =  "success"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PurchaseProducts(List<Order> orders) {

            if (ModelState.IsValid) {
                foreach (var item in orders)
                {
                    item.DateCreated = DateTime.Now;
                }
                db.Orders.AddRange(orders);
                db.SaveChanges();
                ViewBag.PurchaseMessage = "success";
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }


            //return View();
            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }


    }
}