﻿namespace WebApi.Controllers
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
        public void InsertCourse(Course course)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.InsertCourse(course, ref errors);
        }

        [HttpGet]
        public List<Course> GetFinishedCourses(string id)
        {
            var errors = new List<string>();
            var repository = new CourseRepository();
            var service = new CourseService(repository);
            return service.GetFinishedCourses(id, ref errors);
        }

        [HttpGet]
        public List<Course> GetUnfinishedCourses(string id)
        {
            var errors = new List<string>();
            var repository = new CourseRepository();
            var service = new CourseService(repository);
            return service.GetUnfinishedCourses(id, ref errors);
        }


        [HttpPost]
        public void DeleteCourse(string id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.DeleteCourse(id, ref errors);
        }

        [HttpPost]
        public void UpdateCourse(Course course)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            service.UpdateCourse(course, ref errors);
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