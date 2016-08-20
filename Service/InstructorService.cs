namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class InstructorService
    {
        private readonly IInstructorRepository repository;

        public InstructorService(IInstructorRepository repository)
        {
            this.repository = repository;
        }


        public void InstructorInputCheck(Instructor instructor, ref List<string> errors)
        {

            if (instructor.InstructorId < 0)
            {
                errors.Add("Instructor ID must not be negative.");
                throw new ArgumentException();
            }
            if (instructor.FirstName.Length > Constants.INSTRUCTOR_FIRST_NAME_MAX || String.IsNullOrEmpty(instructor.FirstName))
            {
                errors.Add("Instructor first name must be between 1-50 characters.");
                throw new ArgumentException();
            }
            if (instructor.LastName.Length > Constants.INSTRUCTOR_LAST_NAME_MAX || String.IsNullOrEmpty(instructor.LastName))
            {
                errors.Add("Instructor last name must be between 1-50 characters.");
                throw new ArgumentException();
            }
            if (instructor.Title.Length > Constants.INSTRUCTOR_TITLE_MAX || String.IsNullOrEmpty(instructor.Title))
            {
                errors.Add("Instructor title must be between 1-50 characters.");
                throw new ArgumentException();
            }

            repository.InsertInstructor(instructor, ref errors);

        }

    }
}
