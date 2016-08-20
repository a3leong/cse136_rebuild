namespace POCO
{
    using System.Collections.Generic;

    public class Major
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }

        public string ShorthandName { get; set; }

        public string Description { get; set; }

        public List<Course> CourseRequirements { get; set; }

        public override string ToString()
        {
            return this.Id + "-"
                + this.FullName + "-"
                + this.ShorthandName + "-"
                + this.Description;
        }
    }
}
