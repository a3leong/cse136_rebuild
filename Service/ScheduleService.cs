namespace Service
{
    using System.Collections.Generic;
    using System;
    using IRepository;
    using POCO;
    using System.Text.RegularExpressions;


    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public bool ScheduleInputCheck(Schedule schedule, ref List<string> errors)
        {

            if (schedule.ScheduleId < 0)
            {
                errors.Add("Schedule ID must not be negative.");
                throw new ArgumentException();
            }
            if (schedule.Course == null)
            {
                errors.Add("Course must be set.");
                throw new ArgumentException();
            }
            // YEAR 19XX-20XX
            if (!Regex.IsMatch(schedule.Year, "^(19|20)[0-9][0-9]"))
            {
                errors.Add("Year must be of the form 19XX - 20XX.");
                throw new ArgumentException();
            }
            if (schedule.Quarter.Length > Constants.COURSE_SCHEDULE_QUARTER_MAX || String.IsNullOrEmpty(schedule.Quarter))
            {
                errors.Add("Schedule Quarter must be between 1-50 character.");
                throw new ArgumentException();
            }
            if (schedule.Session.Length > Constants.COURSE_SCHEDULE_SESSION_MAX || String.IsNullOrEmpty(schedule.Session))
            {
                errors.Add("Schedule session must be within 1 to 50 characters.");
                throw new ArgumentException();
            }

            return true;
        }


        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }
    }
}
