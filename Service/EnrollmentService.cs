namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class EnrollmentService
    {
        // private readonly IAdminRepository repository;
        public void EnrollmentInputCheck(Enrollment enrollment, ref List<string> errors)
        {
            if (enrollment.StudentId.Length > Constants.ENROLLMENT_STUDENT_ID_MAX || string.IsNullOrEmpty(enrollment.StudentId))
            {
                errors.Add("Student ID must be within 1-20 characters.");
                throw new ArgumentException();
            }

            if (enrollment.ScheduleId < 0)
            {
                errors.Add("Schedule ID must not be negative.");
                throw new ArgumentException();
            }

            if (enrollment.Grade.Length > Constants.ENROLLMENT_GRADE_MAX || string.IsNullOrEmpty(enrollment.Grade))
            {
                errors.Add("Grade must be between 1 to 10 characters.");
                throw new ArgumentException();
            }

            if (enrollment.complete != 0 || enrollment.complete != 1)
            {
                errors.Add("Completed bit must be 0 (incomplete) or 1 (complete).");
                throw new ArgumentException();
            }
        }
    }
}
