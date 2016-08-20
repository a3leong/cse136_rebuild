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

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            if (!this.IsValidInstructor(instructor, ref errors))
            {
                throw new ArgumentException();
            }

            repository.InsertInstructor(instructor, ref errors);
        }

        public void UpdateInstructor(Instructor instructor, ref List<string> errors)
        {
            if (!this.IsValidInstructor(instructor, ref errors))
            {
                throw new ArgumentException();
            }

            repository.UpdateInstructor(instructor, ref errors);
        }

        public void GetInstructor(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Id cannot be null or empty");
                throw new ArgumentException();
            }

            repository.GetInstructorDetail(id, ref errors);
        }

        public void DeleteInstructor(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Id cannot be null or empty");
                throw new ArgumentException();
            }

            repository.DeleteInstructor(id, ref errors);
        }

        private bool IsValidInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
                return false;
            }

            if (instructor.InstructorId < 0)
            {
                errors.Add("Instructor ID must not be negative");
                return false;
            }

            if (instructor.FirstName.Length > Constants.INSTRUCTOR_FIRST_NAME_MAX || string.IsNullOrEmpty(instructor.FirstName))
            {
                errors.Add("Instructor first name must be between 1-50 characters");
                return false;
            }

            if (instructor.LastName.Length > Constants.INSTRUCTOR_LAST_NAME_MAX || string.IsNullOrEmpty(instructor.LastName))
            {
                errors.Add("Instructor last name must be between 1-50 characters");
                return false;
            }

            if (instructor.Title.Length > Constants.INSTRUCTOR_TITLE_MAX || string.IsNullOrEmpty(instructor.Title))
            {
                errors.Add("Instructor title must be between 1-50 characters");
                return false;
            }

            return true;
        }
    }
}
