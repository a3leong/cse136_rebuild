namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IStaffRepository
    {
        void InsertStaff(Staff staff, ref List<string> errors);

        void UpdateStaff(Staff staff, ref List<string> errors);
    }
}
