namespace POCO
{
    using System.Collections.Generic;

    public class Instructor
    {
        public int InstructorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return this.InstructorId + "-"
                + this.FirstName + "-"
                + this.LastName + "-"
                + this.Title;
        }
    }
}
