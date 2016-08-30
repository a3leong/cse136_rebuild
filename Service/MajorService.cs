namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class MajorService
    {
        private readonly IMajorRepository repository;

        public MajorService(IMajorRepository repository)
        {
            this.repository = repository;
        }

        public void InsertMajor(Major major, ref List<string> errors)
        {
            if (!this.IsValidMajor(major, ref errors))
            {
                throw new ArgumentException();
            }

            this.repository.InsertMajor(major, ref errors);
        }

        public void UpdateMajor(Major major, ref List<string> errors)
        {
            if (!this.IsValidMajor(major, ref errors))
            {
                throw new ArgumentException();
            }

            this.repository.UpdateMajor(major, ref errors);
        }

        public Major GetMajor(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid major id");
                throw new ArgumentException();
            }

            return this.repository.GetMajorDetail(id, ref errors);
        }

        public void DeleteMajor(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid major id");
                throw new ArgumentException();
            }

            this.repository.DeleteMajor(id, ref errors);
        }

        public List<Major> GetMajorList(ref List<string> errors)
        {
            return this.repository.GetMajorList(ref errors);
        }

        public List<Course> GetMajorRequirements(string id, ref List<string> errors)
        {
            return this.repository.GetMajorRequirements(id, ref errors);
        }

        private bool IsValidMajor(Major major, ref List<string> errors)
        {
            if (major == null)
            {
                errors.Add("Major cannot be null");
                return false;
            }

            if (string.IsNullOrEmpty(major.FullName) || string.IsNullOrEmpty(major.ShorthandName))
            {
                errors.Add("FullName/ShorthandName cannot be null or empty");
                return false;
            }

            if (major.FullName.Length < 6)
            {
                errors.Add("Fullname must be more than 5 characters");
                return false;
            }

            if (major.FullName.Length > 50)
            {
                errors.Add("Fullname must be less than 50 characters");
                return false;
            }

            if (major.ShorthandName.Length != 3)
            {
                errors.Add("Shorthand name must be exactly 3 characters");
                return false;
            }

            Regex shorthandRegex = new Regex(@"^[A-Z0-9]{3}$");
            if (!shorthandRegex.Match(major.ShorthandName).Success)
            {
                errors.Add("Shorthand characters must all be caps and only letters");
                return false;
            }

            if (major.Description.Length > 500)
            {
                errors.Add("Description must be 500 characters or less");
                return false;
            }

            return true;
        }
    }
}
