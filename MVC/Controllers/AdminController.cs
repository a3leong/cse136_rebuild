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

        public ActionResult EditMajors()
        {
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }

        public ActionResult ManageScheduleDayTable()
        {
            return this.View();
        }

        public ActionResult ManageScheduleTimeTable()
        {
            return this.View();
        }
        
        public ActionResult NewCoursePlan()
        {
            return this.View();
        }
        
        public ActionResult NewCourseSchedule()
        {
            return this.View();
        }
    }
}
