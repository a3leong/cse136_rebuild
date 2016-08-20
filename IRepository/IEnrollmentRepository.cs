namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        void InsertEnrollment(Enrollment enrollment, ref List<string> errors);

        void UpdateInstructor(Enrollment enrollment, ref List<string> errors);

        void DeleteEnrollment(string id, ref List<string> errors);

        Instructor GetEnrollmentDetail(string id, ref List<string> errors);

        List<Instructor> GetEnrollmentList(ref List<string> errors);
    }
}
