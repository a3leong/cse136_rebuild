namespace Service
{
    using System.Collections.Generic;
    using System;
    using IRepository;

    using POCO;

    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public bool ValidateEntry(Course course, ref List<string> errors)
        {
            
            int checkVal = 0;
            Int32.TryParse(course.CourseId, out checkVal);

            if (checkVal < 0)
            {
                errors.Add("Id must not be negative.");
                return false;
            }
            if (course.Title.Length > Constants.COURSE_TITLE_MAX || String.IsNullOrEmpty(course.Title))
            {
                errors.Add("Course title must be within 1 to 100 characters.");
                return false;
            }
            if (course.CourseLevel == null)
            {
                errors.Add("Course level should be set.");
                return false;
            }
            if (course.Description.Length > Constants.COURSE_DESC_MAX || String.IsNullOrEmpty(course.Description))
            {
                errors.Add("Course description should have at least 1 character.");
                return false;
            }
            return true;
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }

        public void InsertCourse(Course course, ref List<string> errors)
        {
            if (!ValidateEntry(course, ref errors))
            {
                throw new ArgumentException();
            }
            else
            {
                repository.InsertCourse(course, ref errors);
            }
        }

        public void DeleteCourse(String id, ref List<string> errors)
        {
            repository.DeleteCourse(id, ref errors);
        }

        public void UpdateCourse(Course course, ref List<string> errors)
        {
            if (!ValidateEntry(course, ref errors))
            {
                throw new ArgumentException();
            }
            else
            {
                repository.UpdateCourse(course, ref errors);
            }
        }

        public Course GetCourseDetails(string id, ref List<string> errors)
        {
            return repository.GetCourseDetails(id, ref errors);
        }

        public List<Course> GetFinishedCourses(string id, ref List<string> errors)
        {
            return repository.GetFinishedCoursesByStudent(id, ref errors);
        }

        public List<Course> GetUnfinishedCourses(string id, ref List<string> errors)
        {
            return repository.GetUnfinishedCoursesByStudent(id, ref errors);
        }
    }
}
