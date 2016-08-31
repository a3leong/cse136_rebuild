namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        void InsertCourse(Course course, ref List<string> errors);

        void UpdateCourse(Course course, ref List<string> errors);

        void DeleteCourse(string id, ref List<string> errors);

        Course GetCourseDetails(string id, ref List<string> errors);

        List<Course> GetCourseList(ref List<string> errors);

        List<Course> GetFinishedCoursesByStudent(string id, ref List<string> errors);

        List<Course> GetUnfinishedCoursesByStudent(string id, ref List<string> errors);

        void InsertPrereq(string course_id, string prereq_id, ref List<string> errors);

        void DeletePrereq(string course_id, string prereq_id, ref List<string> errors);
    }
}
