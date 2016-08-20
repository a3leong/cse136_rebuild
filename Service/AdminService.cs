namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class AdminService
    {
        //private readonly IAdminRepository repository;
        public bool ValidateAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Admin cannot be null");
                return false;
            }

            if (admin.Id <= 0)
            {
                errors.Add("Admin ID cannot be negative");
                return false;
            }

            if (admin.email.Length > Constants.ADMIN_LENGTH_MAX || string.IsNullOrEmpty(admin.email))
            {
                errors.Add("Email must be between 1 and 50 characters");
                return false;

            }

            try
            {
                string regex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                if (!Regex.IsMatch(admin.email, regex, RegexOptions.IgnoreCase))
                {
                    errors.Add("Email must be in a ____@___.__ format");
                    return false;

                }
            }
            catch (Exception)
            {
                errors.Add("Email format is erroneous");
                return false;

            }

            if (admin.password.Length > Constants.ADMIN_LENGTH_MAX || string.IsNullOrEmpty(admin.password))
            {
                errors.Add("Password must be within 1 and 50 characters");
                return false;
            }

            return true;
        }
    }
}