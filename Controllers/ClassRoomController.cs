using _123.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _123.Controllers
{
    public class ClassRoomController : Controller
    {
        //
        // GET: /ClassRoom/
        public ActionResult Index()
        {
            using (SchoolEntities1 dbmodel3 = new SchoolEntities1())
            {
                return View(dbmodel3.Classrooms.ToList());
            }
        }

        //
        // GET: /ClassRoom/Details/5
        public ActionResult Details(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Classrooms.Where(x => x.Classroom_ID == id).FirstOrDefault());
            }
        }

        //
        // GET: /ClassRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClassRoom/Create
        [HttpPost]
        public ActionResult Create(Classroom room)
        {
            try
            {
                using (SchoolEntities1 dbModel1 = new SchoolEntities1())
                {
                    dbModel1.Classrooms.Add(room);
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
        // GET: /ClassRoom/Edit/5
        public ActionResult Edit(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Classrooms.Where(x => x.Classroom_ID == id).FirstOrDefault());
            }
        }

        //
        // POST: /ClassRoom/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Classroom room)
        {
            try
            {
                using (SchoolEntities1 dbModel = new SchoolEntities1())
                {
                    dbModel.Entry(room).State = EntityState.Modified;
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
        // GET: /ClassRoom/Delete/5
        public ActionResult Delete(int id)
        {
            using (SchoolEntities1 dbModel = new SchoolEntities1())
            {
                return View(dbModel.Classrooms.Where(x => x.Classroom_ID == id).FirstOrDefault());
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
                    Classroom course = dbModel.Classrooms.Where(x => x.Classroom_ID == id).FirstOrDefault();
                    dbModel.Classrooms.Remove(course);
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
