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
{   [Authorize]
    public class FinishedItemsController : Controller
    {
        private ChainmailDBContext db = new ChainmailDBContext();

        // GET: FinishedItems
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.FinishedItems.ToList());
            }
            
            List<FinishedItem> UnsoldItems = db.FinishedItems.Select(m => m).Where(s => s.HasBeenPurchased == false).ToList();
            return View(UnsoldItems.ToList());
        }

        // GET: FinishedItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedItem finishedItem = db.FinishedItems.Find(id);
            if (finishedItem == null)
            {
                return HttpNotFound();
            }
            return View(finishedItem);
        }

        // GET: FinishedItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinishedItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description")] FinishedItem finishedItem)
        {
            if (ModelState.IsValid)
            {
                db.FinishedItems.Add(finishedItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finishedItem);
        }

        // GET: FinishedItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedItem finishedItem = db.FinishedItems.Find(id);
            if (finishedItem == null)
            {
                return HttpNotFound();
            }
            return View(finishedItem);
        }

        // POST: FinishedItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description")] FinishedItem finishedItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finishedItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finishedItem);
        }

        // GET: FinishedItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedItem finishedItem = db.FinishedItems.Find(id);
            if (finishedItem == null)
            {
                return HttpNotFound();
            }
            return View(finishedItem);
        }

        // POST: FinishedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishedItem finishedItem = db.FinishedItems.Find(id);
            db.FinishedItems.Remove(finishedItem);
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
