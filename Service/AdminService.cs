namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System.Text.RegularExpressions;

    public class Constants
    {
        public const int ADMIN_LENGTH_MAX = 50;
        public const int ENROLLMENT_STUDENT_ID_MAX = 20;
        public const int ENROLLMENT_GRADE_MAX = 10;
        public const int INSTRUCTOR_FIRST_NAME_MAX = 50;
        public const int INSTRUCTOR_LAST_NAME_MAX = 50;
        public const int INSTRUCTOR_TITLE_MAX = 50;
        public const int STAFF_EMAIL_MAX = 50;
        public const int STAFF_PASSWORD_MAX = 50;
    }

    public class AdminService
    {
        //private readonly IAdminRepository repository;

        public void AdminInputCheck(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Admin cannot be null.");
                throw new ArgumentException();
            }
            if (admin.Id <= 0)
            {
                errors.Add("Admin ID cannot be negative.");
                throw new ArgumentException();
            }
            if (admin.email.Length > Constants.ADMIN_LENGTH_MAX || String.IsNullOrEmpty(admin.email))
            {
                errors.Add("Email must be between 1 and 50 characters.");
                throw new ArgumentException();
            }
            try
            {
                if (!Regex.IsMatch(admin.email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                     RegexOptions.IgnoreCase))
                {
                    errors.Add("Email must be in a ____@___.__ format.");
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                errors.Add("Email format is erroneous.");
                throw new ArgumentException();
            }
            if (admin.password.Length > Constants.ADMIN_LENGTH_MAX || String.IsNullOrEmpty(admin.password))
            {
                errors.Add("Password must be within 1 and 50 characters.");
                throw new ArgumentException();
            }

        }
    }
}
