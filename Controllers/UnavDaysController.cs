using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _123.Models;

namespace _123.Controllers
{
    public class UnavDaysController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: /UnavDays/
        public ActionResult Index()
        {
            var unavailable_days = db.Unavailable_Days.Include(u => u.Teacher);
            return View(unavailable_days.ToList());
        }

        // GET: /UnavDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavailable_Days unavailable_days = db.Unavailable_Days.Find(id);
            if (unavailable_days == null)
            {
                return HttpNotFound();
            }
            return View(unavailable_days);
        }

        // GET: /UnavDays/Create
        public ActionResult Create()
        {
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName");
            return View();
        }

        // POST: /UnavDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Teacher_ID,MondayMorning,MondayAfternoon,TuesdayMorning,TuesdayAfternoon,WednesdayMorning,WednesdayAfternoon,ThursdayMorning,ThursdayAfternoon,FridayMorning,FridayAfrernoon")] Unavailable_Days unavailable_days)
        {
            if (ModelState.IsValid)
            {
                db.Unavailable_Days.Add(unavailable_days);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavailable_days.Teacher_ID);
            return View(unavailable_days);
        }

        // GET: /UnavDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavailable_Days unavailable_days = db.Unavailable_Days.Find(id);
            if (unavailable_days == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavailable_days.Teacher_ID);
            return View(unavailable_days);
        }

        // POST: /UnavDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Teacher_ID,MondayMorning,MondayAfternoon,TuesdayMorning,TuesdayAfternoon,WednesdayMorning,WednesdayAfternoon,ThursdayMorning,ThursdayAfternoon,FridayMorning,FridayAfrernoon")] Unavailable_Days unavailable_days)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unavailable_days).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavailable_days.Teacher_ID);
            return View(unavailable_days);
        }

        // GET: /UnavDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavailable_Days unavailable_days = db.Unavailable_Days.Find(id);
            if (unavailable_days == null)
            {
                return HttpNotFound();
            }
            return View(unavailable_days);
        }

        // POST: /UnavDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unavailable_Days unavailable_days = db.Unavailable_Days.Find(id);
            db.Unavailable_Days.Remove(unavailable_days);
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
