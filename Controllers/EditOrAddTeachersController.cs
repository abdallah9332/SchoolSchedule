using _123.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _123.Controllers
{
    public class EditOrAddTeachersController : Controller
    {
        public ActionResult Index()
        {
            using (SchoolEntities1 dbmodel1 = new SchoolEntities1())
            {
                return View(dbmodel1.Teachers.ToList());
            }
        }


        //
        // GET: /EditOrDeleteLesson/Details/5
        public ActionResult Details(int id)
        {
            using (SchoolEntities1 dbModel1 = new SchoolEntities1())
            {
                return View(dbModel1.Teachers.Where(x => x.Teacher_ID == id).FirstOrDefault());
            }
        }

        //
        // GET: /EditOrDeleteLesson/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EditOrDeleteLesson/Create
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                using (SchoolEntities1 dbModel = new SchoolEntities1())
                {
                    dbModel.Teachers.Add(teacher);
                    dbModel.SaveChanges();
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
                return View(dbModel.Teachers.Where(x => x.Teacher_ID == id).FirstOrDefault());
            }
        }

        //
        // POST: /EditOrDeleteLesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                using (SchoolEntities1 dbModel = new SchoolEntities1())
                {
                    dbModel.Entry(teacher).State = EntityState.Modified;
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
                return View(dbModel.Teachers.Where(x => x.Teacher_ID == id).FirstOrDefault());
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
                    Teacher teacher = dbModel.Teachers.Where(x => x.Teacher_ID == id).FirstOrDefault();
                    dbModel.Teachers.Remove(teacher);
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