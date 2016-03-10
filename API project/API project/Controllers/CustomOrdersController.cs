using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API_project.Models;
using Microsoft.AspNet.Identity;

namespace API_project.Controllers
{   [Authorize]
    public class CustomOrdersController : Controller
    {
        private ChainmailDBContext db = new ChainmailDBContext();

        // GET: CustomOrders
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.CustomOrders.ToList());
            }
            string userId = User.Identity.GetUserId();
            List<CustomOrder> userOrders = db.CustomOrders.Select(m => m).Where(s => s.CustomerID == userId).ToList();
            return View(userOrders.ToList());
        }

        // GET: CustomOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrder customOrder = db.CustomOrders.Find(id);
            if (customOrder == null)
            {
                return HttpNotFound();
            }
            return View(customOrder);
        }

        // GET: CustomOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,RequestDescription")] CustomOrder customOrder)
        {
            if (ModelState.IsValid)
            {

                customOrder.CustomerID = User.Identity.GetUserId();
                db.CustomOrders.Add(customOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customOrder);
        }

        // GET: CustomOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrder customOrder = db.CustomOrders.Find(id);
            if (customOrder == null)
            {
                return HttpNotFound();
            }
            return View(customOrder);
        }

        // POST: CustomOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,CustomerID,RequestDescription")] CustomOrder customOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customOrder);
        }

        // GET: CustomOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrder customOrder = db.CustomOrders.Find(id);
            if (customOrder == null)
            {
                return HttpNotFound();
            }
            return View(customOrder);
        }

        // POST: CustomOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomOrder customOrder = db.CustomOrders.Find(id);
            db.CustomOrders.Remove(customOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
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
