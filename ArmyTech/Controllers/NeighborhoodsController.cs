using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyTech.Models;

namespace ArmyTech.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private ArmyTechTaskEntities db = new ArmyTechTaskEntities();

        // GET: Neighborhoods
        public ActionResult Index()
        {
            var neighborhoods = db.Neighborhoods.Include(n => n.Governorate);
            return View(neighborhoods.ToList());
        }

        // GET: Neighborhoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public ActionResult Create()
        {
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name");
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GovernorateId")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                db.Neighborhoods.Add(neighborhood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", neighborhood.GovernorateId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", neighborhood.GovernorateId);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GovernorateId")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neighborhood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", neighborhood.GovernorateId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            db.Neighborhoods.Remove(neighborhood);
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
