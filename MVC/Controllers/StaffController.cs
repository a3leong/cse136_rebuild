﻿namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class StaffController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }

        public ActionResult CreateStudent()
        {
            return this.View();
        }

        public ActionResult EditStudent(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CourseList(string id)
        {
            ViewBag.id = id;
            return this.View();
        }
    }
}
