using _123.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _123.Controllers
{
    public class EditOrDeleteLessonController : Controller
    {
        public ActionResult Index()
        {
            using (SchoolEntities1 dbmodel3 = new SchoolEntities1())
            {
                return View(dbmodel3.Courses.ToList());
            }
        }


        //
        // GET: /EditOrDeleteLesson/Details/5
        public ActionResult Details(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Courses.Where(x => x.Course_ID == id).FirstOrDefault());
            }
        }

        //
        // GET: /EditOrDeleteLesson/Create
        public ActionResult Create()
        {
            SchoolEntities1 db = new SchoolEntities1();
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "TeacherName");
            return View();
        }

        //
        // POST: /EditOrDeleteLesson/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                using (SchoolEntities1 dbModel1 = new SchoolEntities1())
                {
                    dbModel1.Courses.Add(course);
                    dbModel1.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EditOrDeleteLesson/Edit/5
        public ActionResult Edit(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Courses.Where(x => x.Course_ID == id).FirstOrDefault());
            }
        }

        //
        // POST: /EditOrDeleteLesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                using (SchoolEntities1 dbModel = new SchoolEntities1())
                {
                    dbModel.Entry(course).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EditOrDeleteLesson/Delete/5
        public ActionResult Delete(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Courses.Where(x => x.Course_ID == id).FirstOrDefault());
            }

        }

        //
        // POST: /EditOrDeleteLesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (SchoolEntities1 dbModel = new SchoolEntities1())
                {
                    Course course = dbModel.Courses.Where(x => x.Course_ID == id).FirstOrDefault();
                    dbModel.Courses.Remove(course);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
