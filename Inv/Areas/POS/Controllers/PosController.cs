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

        //[HttpPost]
        //public ActionResult ModelBinding([ModelBinder(typeof(DevExpressEditorsBinder))] MyModelData myModel)
        //{
        //...
        //}

        // GET: POS/Pos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsGridViewCallback(string searchString) {
            ViewBag.searchString = searchString;
            return PartialView("_ProductsGridViewCallback");
        }

        public ActionResult ProductsGridView(string searchString){

            var products = db.Products;
            if (!String.IsNullOrEmpty(searchString)) {
                products.Where(q => q.ProductName.Contains(searchString));
            }
            return PartialView("_ProductsGridView", products.ToList());
        }
    }
}