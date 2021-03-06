﻿namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult MajorList()
        {
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }
        
        /**
        public ActionResult ManageCourseSchedule()
        {
            return this.View();
        }
         **/

        public ActionResult InstructorList()
        {
            return this.View();
        }

        public ActionResult EditMajor(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CreateMajor()
        {
            return this.View();
        }

        public ActionResult MajorRequirements(string id, string name)
        {
            ViewBag.name = name;
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CreateCourse()
        {
            return this.View();
        }

        public ActionResult EditCourse(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult EditInstructor(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CreateInstructor()
        {
            return this.View();
        }

        public ActionResult Prereqs(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult StudentAudit(string id)
        {
            ViewBag.id = id;
            return this.View();
        }
    }
}
