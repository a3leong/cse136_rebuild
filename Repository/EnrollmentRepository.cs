namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using IRepository;
    using POCO;

    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        private const string GetEnrollmentListProcedure = "spGetEnrollmentList";

        public List<Enrollment> GetEnrollmentList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrollmentListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var enrollment = new Enrollment
                    {
                        StudentId = (dataSet.Tables[0].Rows[i]["student_id"].ToString()),
                        ScheduleId = Int32.Parse(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString(),
                        complete = Int32.Parse(dataSet.Tables[0].Rows[i]["completed"].ToString())
                    };
                    enrollmentList.Add(enrollment);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return enrollmentList;
        }
    }
}
