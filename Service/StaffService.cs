namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class StaffService
    {
        private readonly IStaffRepository repository;

        public StaffService(IStaffRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStaff(Staff staff, ref List<string> errors)
        {
            if (!IsValidStaff(staff, ref errors))
            {
                throw new ArgumentException();
            }

            this.repository.InsertStaff(staff, ref errors);
        }

        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            if (!IsValidStaff(staff, ref errors))
            {
                throw new ArgumentException();
            }

            this.repository.UpdateStaff(staff, ref errors);
        }

        private bool IsValidStaff(Staff staff, ref List<string> errors)
        {
            if (staff == null)
            {
                errors.Add("Staff cannot be null");
                return false;
            }

            if (staff.StaffId < 0)
            {
                errors.Add("Staff ID must not be below 0");
                return false;
            }

            if (staff.Email.Length > Constants.STAFF_EMAIL_MAX || string.IsNullOrEmpty(staff.Email))
            {
                errors.Add("Staff email must be within 50 characters");
                return false;
            }
            else
            {
                try
                {
                    string regex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                    if (!Regex.IsMatch(staff.Email, regex, RegexOptions.IgnoreCase))
                    {
                        errors.Add("Staff email must follow the format ___@___.__.");
                        return false;
                    }
                }
                catch (Exception)
                {
                    errors.Add("Staff email has an erroneous format");
                    return false;
                }
            }

            if (staff.Password.Length > Constants.STAFF_PASSWORD_MAX || string.IsNullOrEmpty(staff.Password))
            {
                errors.Add("Password must be within 50 characters");
                return false;
            }

            return true;
        }
    }
}
