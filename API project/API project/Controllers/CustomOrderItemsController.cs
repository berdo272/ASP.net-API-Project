using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API_project.Models;

namespace API_project.Controllers
{
    public class CustomOrderItemsController : Controller
    {
        private ChainmailDBContext db = new ChainmailDBContext();

        // GET: CustomOrderItems
        public ActionResult Index()
        {
            return View(db.CustomItems.ToList());
        }

        // GET: CustomOrderItems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrderItem customOrderItem = db.CustomItems.Find(id);
            if (customOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(customOrderItem);
        }

        // GET: CustomOrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomOrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderID,Description,Price,EstimatedTimeOfCompletion,SellersNotes")] CustomOrderItem customOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.CustomItems.Add(customOrderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customOrderItem);
        }

        // GET: CustomOrderItems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrderItem customOrderItem = db.CustomItems.Find(id);
            if (customOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(customOrderItem);
        }

        // POST: CustomOrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderID,Description,Price,EstimatedTimeOfCompletion,SellersNotes")] CustomOrderItem customOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customOrderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customOrderItem);
        }

        // GET: CustomOrderItems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomOrderItem customOrderItem = db.CustomItems.Find(id);
            if (customOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(customOrderItem);
        }

        // POST: CustomOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomOrderItem customOrderItem = db.CustomItems.Find(id);
            db.CustomItems.Remove(customOrderItem);
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
