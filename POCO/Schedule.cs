namespace POCO
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public Course Course { get; set; }

        public string Instructor { get; set; }

        public int DayId { get; set; }

        public int TimeId { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" + this.Year + "-" + this.Quarter + "-" + this.Session + "-" + this.Course;
        }
    }
}
