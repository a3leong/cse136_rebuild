namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IMajorRepository
    {
        void InsertMajor(Major major, ref List<string> errors);

        void UpdateMajor(Major major, ref List<string> errors);

        void DeleteMajor(string shorthand_id, ref List<string> errors);

        Major GetMajorDetailByShorthand(string shorthand_id, ref List<string> errors);

        List<Major> GetMajorList(ref List<string> errors);
    }
}
