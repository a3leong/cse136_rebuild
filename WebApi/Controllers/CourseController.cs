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
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCourseList(ref errors);
        }

        //// you can add more [HttpGet] and [HttpPost] methods as you need
        [HttpPost]
        public string InsertCourse(Course course)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.InsertCourse(course, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }

        [HttpPost]
        public string DeleteCourse(string id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.DeleteCourse(id, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }

        [HttpPost]
        public string UpdateCourse(Course course)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.UpdateCourse(course, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }

        [HttpGet]
        public Course GetCourseDetails(string id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            return service.GetCourseDetails(id, ref errors);
        }
    }
}