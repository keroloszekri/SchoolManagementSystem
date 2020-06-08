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
    public class StudentsController : Controller
    {
        private ArmyTechTaskEntities db = new ArmyTechTaskEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Field).Include(s => s.Governorate).Include(s => s.Neighborhood);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name");
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name");
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BirthDate,GovernorateId,NeighborhoodId,FieldId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BirthDate,GovernorateId,NeighborhoodId,FieldId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
