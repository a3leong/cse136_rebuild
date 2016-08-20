namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System.Text.RegularExpressions;

    public class StaffService
    {
        private readonly IStaffRepository repository;

        public StaffService(IStaffRepository repository)
        {
            this.repository = repository;
        }

        public void StaffInputCheck(Staff staff, ref List<string> errors)
        {

            if (staff.StaffId < 0)
            {
                errors.Add("Staff ID must not be below 0.");
                throw new ArgumentException();
            }
            if (staff.Email.Length > Constants.STAFF_EMAIL_MAX || String.IsNullOrEmpty(staff.Email))
            {
                errors.Add("Staff email must be within 50 characters.");
                throw new ArgumentException();
            }
            else
            {
                try
                {
                    if (!Regex.IsMatch(staff.Email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                         RegexOptions.IgnoreCase))
                    {
                        errors.Add("Staff email must follow the format ___@___.__.");
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    errors.Add("Staff email has an erroneous format.");
                    throw new ArgumentException();
                }
            }
            if (staff.Password.Length > Constants.STAFF_PASSWORD_MAX || String.IsNullOrEmpty(staff.Password))
            {
                errors.Add("Password must be within 50 characters.");
                throw new ArgumentException();
            }


            this.repository.InsertStaff(staff, ref errors);
        }

        
    }
}
