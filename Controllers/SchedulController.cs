using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _123.Models;

namespace _123.Controllers
{
    public class SchedulController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ToAddd(int semester=1)
        {
            SchoolEntities1 db = new SchoolEntities1();
            List<Course> courseList = db.Courses.Where(a => a.WhichSemester == semester).ToList();
            CourseViewModel courseVM = new CourseViewModel();
            List<CourseViewModel> courseVMList = courseList.Select(x => new CourseViewModel
            {
                CourseName = x.CourseName,
                CourseCode = x.CourseCode,
                TypeOfLesson = x.TypeOfLesson,
                TeacherName = x.Teacher.TeacherName,
                WhichYear = x.WhichYear,
                WhichSemester=x.WhichSemester
            }).ToList();
            return View(courseVMList);
        }

        //public ActionResult ToAddd()
        //{
        //    return RedirectToAction("ToAddd", new { semester = 1 });
        //}
     
	}
}