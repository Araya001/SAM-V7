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
    public class OrganizationsController : Controller
    {
        private SAM_V7Context db = new SAM_V7Context();

        // GET: Organizations
        public ActionResult Index()
        {
            return View(db.Organizations.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizations organizations = db.Organizations.Find(id);
            if (organizations == null)
            {
                return HttpNotFound();
            }
            return View(organizations);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganNo,OrganName,PSUPassport,TitleAdviserName,AdviserName,AdviserLastName,AdviserEmail,AdviserTel,StartPositionDate,EndPositionDate")] Organizations organizations)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organizations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizations);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizations organizations = db.Organizations.Find(id);
            if (organizations == null)
            {
                return HttpNotFound();
            }
            return View(organizations);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganNo,OrganName,PSUPassport,TitleAdviserName,AdviserName,AdviserLastName,AdviserEmail,AdviserTel,StartPositionDate,EndPositionDate")] Organizations organizations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizations);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizations organizations = db.Organizations.Find(id);
            if (organizations == null)
            {
                return HttpNotFound();
            }
            return View(organizations);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Organizations organizations = db.Organizations.Find(id);
            db.Organizations.Remove(organizations);
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
