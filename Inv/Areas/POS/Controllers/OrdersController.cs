using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using Inv.Entities;

namespace Inv.Areas.POS.Controllers
{
    public class OrdersController : Controller
    {
        private InvEntities db = new InvEntities();

        // GET: POS/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.Transaction);
            return View(orders.ToList());
        }

        // GET: POS/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: POS/Orders/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.Transaction_TransactionID = new SelectList(db.Transactions, "TransactionID", "TransactionID");
            return View();
        }

        // POST: POS/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,Quantity,DateCreated,Transaction_TransactionID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order.ProductID);
            ViewBag.Transaction_TransactionID = new SelectList(db.Transactions, "TransactionID", "TransactionID", order.Transaction_TransactionID);
            return View(order);
        }

        // GET: POS/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order.ProductID);
            ViewBag.Transaction_TransactionID = new SelectList(db.Transactions, "TransactionID", "TransactionID", order.Transaction_TransactionID);
            return View(order);
        }

        // POST: POS/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,Quantity,DateCreated,Transaction_TransactionID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order.ProductID);
            ViewBag.Transaction_TransactionID = new SelectList(db.Transactions, "TransactionID", "TransactionID", order.Transaction_TransactionID);
            return View(order);
        }

        // GET: POS/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: POS/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OrdersGridViewPagingPartial(DateTime? from, DateTime? to)
        {
            if (from != null && to != null)
            {
                var orders = db.Orders.Include(o => o.Product).Include(o => o.Transaction).Where(o => o.DateCreated >= from || o.DateCreated <= to).OrderByDescending(o => o.DateCreated);

                ViewData["from"] = from;
                ViewData["to"] = to;

                return PartialView("_OrdersGridViewPagingPartial", orders.ToList());
            }
            else
            {
                return PartialView("_OrdersGridViewPagingPartial", Enumerable.Empty<Order>());
            }
            //return PartialView("_OrdersGridViewPagingPartial");
        }

        public ActionResult OrdersGridViewCallbackPartial(DateTime? from, DateTime? to)
        {
            ViewData["from"] = from;
            ViewData["to"] = to;
            return PartialView("_OrdersGridViewCallbackPartial");
        }


        public ActionResult OrdersGridViewPartial(DateTime? from, DateTime? to) {

            if(from !=null && to != null) { 
                var orders = db.Orders.Include(o => o.Product).Include(o => o.Transaction).Where(o => o.DateCreated >= from || o.DateCreated <= to).OrderByDescending(o => o.DateCreated);
                
                ViewData["from"] = from;
                ViewData["to"] = to;

                return PartialView("_OrdersGridViewPartial",orders.ToList());
            }
            else {
                return PartialView("_OrdersGridViewPartial", Enumerable.Empty<Order>());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
