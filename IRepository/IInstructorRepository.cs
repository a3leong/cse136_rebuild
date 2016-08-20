namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IInstructorRepository
    {
        void InsertInstructor(Instructor instructor, ref List<string> errors);

        void UpdateInstructor(Instructor instructor, ref List<string> errors);

        void DeleteInstructor(string id, ref List<string> errors);

        Instructor GetInstructorDetail(string id, ref List<string> errors);

        List<Instructor> GetInstructorList(ref List<string> errors);
    }
}
