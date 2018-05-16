using _123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authurize(_123.Models.Teacher userModel)
        {
            using (SchoolEntities1 db = new SchoolEntities1())
            {
                var userDetails = db.Teachers.Where(x => x.TeacherName == userModel.TeacherName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong user name or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserId"] = userDetails.Teacher_ID;
                    Session["userName"] = userDetails.TeacherName;
                    return RedirectToAction("Index", "Schedul");
                }
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}