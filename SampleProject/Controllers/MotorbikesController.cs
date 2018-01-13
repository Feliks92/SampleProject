using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleProject;

namespace SampleProject.Controllers
{
    public class MotorbikesController : Controller
    {
        private admin_fgjunterEntities db = new admin_fgjunterEntities();

        // GET: Motorbikes
        public ActionResult Index()
        {
            return View(db.Motorbike.ToList());
        }

        // GET: Motorbikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorbike motorbike = db.Motorbike.Find(id);
            if (motorbike == null)
            {
                return HttpNotFound();
            }
            return View(motorbike);
        }

        // GET: Motorbikes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motorbikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Year,Model,Mileage,Description,Manufacturer")] Motorbike motorbike)
        {
            if (ModelState.IsValid)
            {
                motorbike.DateAdded = System.DateTime.Now;
                db.Motorbike.Add(motorbike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motorbike);
        }

        // GET: Motorbikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorbike motorbike = db.Motorbike.Find(id);
            if (motorbike == null)
            {
                return HttpNotFound();
            }
            return View(motorbike);
        }

        // POST: Motorbikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Year,Model,Mileage,Description,Manufacturer")] Motorbike motorbike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorbike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motorbike);
        }

        // GET: Motorbikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorbike motorbike = db.Motorbike.Find(id);
            if (motorbike == null)
            {
                return HttpNotFound();
            }
            return View(motorbike);
        }

        // POST: Motorbikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorbike motorbike = db.Motorbike.Find(id);
            db.Motorbike.Remove(motorbike);
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
