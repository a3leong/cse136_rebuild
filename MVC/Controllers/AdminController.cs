namespace MVC.Controllers
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

        public ActionResult EditMajor(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CreateMajor()
        {
            return this.View();
        }

        public ActionResult CreateCourse()
        {
            return this.View();
        }

        public ActionResult EditCourse()
        {
            return this.View();
        }
    }
}
