using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _123.Models;


namespace _123.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult AddNewLesson(int id = 0)
        {
            Course userModel1 = new Course();
            return View(userModel1);
        }
        [HttpPost]
        public ActionResult AddNewLesson(Course userModel1)
        {
            using (SchoolEntities1 dbModel1 = new SchoolEntities1())
            {
                dbModel1.Courses.Add(userModel1);
                dbModel1.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMessage = "Added successful";
            return View("AddNewLesson", new Course());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Teacher userModel = new Teacher();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Teacher userModel)
        {
            using (SchoolEntities1 dbmodel = new SchoolEntities1())
            {

                if (dbmodel.Teachers.Any(x => x.TeacherName == userModel.TeacherName))
                {
                    ViewBag.DuplicateMessage = "user name already exist.";
                    return View("AddOrEdit", userModel);
                }

                dbmodel.Teachers.Add(userModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Regesteration successfull.";
            return View("AddOrEdit", new Teacher());
        }
      
        //[HttpPost]
        //public ActionResult unavailableDays(int teacher = 5, List<Unavailable_Days> days)
        //{
        //    SchoolEntities1 db = new SchoolEntities1();
        //    foreach (Unavailable_Days item in days)
        //    {
        //        Unavailable_Days updateday = db.Unavailable_Days.ToList().Find(p => p.Teacher_ID == item.Teacher_ID);
        //        Teacher tch = new Teacher();
        //        if (tch.Teacher_ID == teacher)
        //        {
        //            tch.Unavailable_Days = item;
        //        }
        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("unavailableDays");
        //}
    
    }
}
