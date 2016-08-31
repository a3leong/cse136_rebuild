namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IMajorRepository
    {
        void InsertMajor(Major major, ref List<string> errors);

        void UpdateMajor(Major major, ref List<string> errors);

        void DeleteMajor(string shorthand_id, ref List<string> errors);

        Major GetMajorDetail(string shorthand_id, ref List<string> errors);

        List<Course> GetMajorRequirements(string id, ref List<string> errors);

        List<Major> GetMajorList(ref List<string> errors);

        void InsertRequirement(string major_id, string course_id, ref List<string> errors);

        void DeleteRequirement(string major_id, string course_id, ref List<string> errors);
    }
}
