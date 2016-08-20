namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using IRepository;
    using POCO;

    public class StaffRepository : BaseRepository, IStaffRepository
    {
        private const string InsertStaffMember = "INSERT INTO staff(staff_id, email, password) values(@id, @email, @password)";
        private const string UpdateStaffInfo = "UPDATE staff SET email=@email, password=@password WHERE staff_id=@id)";
        
        public void InsertStaff(Staff staff, ref List<string> errors)
        {

            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertStaffMember, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.Text
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@id"].Value = staff.StaffId;
                adapter.SelectCommand.Parameters["@email"].Value = staff.Email;
                adapter.SelectCommand.Parameters["@password"].Value = staff.Password;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStaffInfo, conn)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@id"].Value = staff.StaffId;
                adapter.SelectCommand.Parameters["@email"].Value = staff.Email;
                adapter.SelectCommand.Parameters["@password"].Value = staff.Password;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

    }
}
