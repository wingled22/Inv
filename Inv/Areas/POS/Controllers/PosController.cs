using DevExpress.Web.Mvc;
using Inv.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public JsonResult SaveOrders(string searchString)
        {
            ViewBag.searchString = searchString;

            return Json("_ProductsGridViewCallbackPartial");
        }

    }
}