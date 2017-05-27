using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAM_V7.Models;

namespace SAM_V7.Controllers
{
    public class ApproversController : Controller
    {
        private SAM_V7Context db = new SAM_V7Context();

        // GET: Approvers
        public ActionResult Index()
        {
            return View(db.Approvers.ToList());
        }

        // GET: Approvers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approvers approvers = db.Approvers.Find(id);
            if (approvers == null)
            {
                return HttpNotFound();
            }
            return View(approvers);
        }

        

        // GET: Approvers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Approvers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PSUPassport,TitleName,Name,LastName,OrganName,Position,Email,Tel")] Approvers approvers)
        {
            if (ModelState.IsValid)
            {
                db.Approvers.Add(approvers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approvers);
        }

        // GET: Approvers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approvers approvers = db.Approvers.Find(id);
            if (approvers == null)
            {
                return HttpNotFound();
            }
            return View(approvers);
        }

        // POST: Approvers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PSUPassport,TitleName,Name,LastName,OrganName,Position,Email,Tel")] Approvers approvers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approvers);
        }

        // GET: Approvers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approvers approvers = db.Approvers.Find(id);
            if (approvers == null)
            {
                return HttpNotFound();
            }
            return View(approvers);
        }

        // POST: Approvers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Approvers approvers = db.Approvers.Find(id);
            db.Approvers.Remove(approvers);
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
