namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CourseController : ApiController
    {
        [HttpGet]
        public List<Course> GetCourseList()
        {
            var service = new CourseService(new CourseRepository());
            var error = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCourseList(ref error);
        }

        //// you can add more [HttpGet] and [HttpPost] methods as you need
        [HttpPost]
        public void InsertCourse(Course course, ref List<string> errors)
        {
            var service = new CourseService(new CourseRepository());
            service.InsertCourse(course, ref errors);
        }

        [HttpPost]
        public void DeleteCourse(string id, ref List<string> errors)
        {
            var service = new CourseService(new CourseRepository());
            service.DeleteCourse(id, ref errors);
        }

        [HttpPost]
        public void UpdateCourse(Course course, ref List<string> errors)
        {
            var service = new CourseService(new CourseRepository());
            service.UpdateCourse(course, ref errors);
        }

        [HttpGet]
        public Course GetCourseDetails(string id, ref List<string> errors)
        {
            var service = new CourseService(new CourseRepository());
            return service.GetCourseDetails(id, ref errors);
        }
    }
}