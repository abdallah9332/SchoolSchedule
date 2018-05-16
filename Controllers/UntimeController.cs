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
    public class UntimeController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: /Untime/
        public ActionResult Index()
        {
            var unavaliable_time = db.Unavaliable_Time.Include(u => u.Teacher);
            return View(unavaliable_time.ToList());
        }

        // GET: /Untime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavaliable_Time unavaliable_time = db.Unavaliable_Time.Find(id);
            if (unavaliable_time == null)
            {
                return HttpNotFound();
            }
            return View(unavaliable_time);
        }

        // GET: /Untime/Create
        public ActionResult Create()
        {
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName");
            return View();
        }

        // POST: /Untime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Teacher_ID,Morning,Noon,Afternoon,Evning,Night")] Unavaliable_Time unavaliable_time)
        {
            if (ModelState.IsValid)
            {
                db.Unavaliable_Time.Add(unavaliable_time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavaliable_time.Teacher_ID);
            return View(unavaliable_time);
        }

        // GET: /Untime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavaliable_Time unavaliable_time = db.Unavaliable_Time.Find(id);
            if (unavaliable_time == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavaliable_time.Teacher_ID);
            return View(unavaliable_time);
        }

        // POST: /Untime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Teacher_ID,Morning,Noon,Afternoon,Evning,Night")] Unavaliable_Time unavaliable_time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unavaliable_time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName", unavaliable_time.Teacher_ID);
            return View(unavaliable_time);
        }

        // GET: /Untime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unavaliable_Time unavaliable_time = db.Unavaliable_Time.Find(id);
            if (unavaliable_time == null)
            {
                return HttpNotFound();
            }
            return View(unavaliable_time);
        }

        // POST: /Untime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unavaliable_Time unavaliable_time = db.Unavaliable_Time.Find(id);
            db.Unavaliable_Time.Remove(unavaliable_time);
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
