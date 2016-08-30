namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using IRepository;
    using POCO;
    using System.Diagnostics;

    public class InstructorRepository : BaseRepository, IInstructorRepository
    {
        private const string InsertInstructorInfoProcedure = "spInsertInstructor";
        private const string UpdateInstructorInfoProcedure = "spUpdateInstructor";
        private const string DeletInstructorInfoProcedure = "spDeleteInstructor";
        private const string GetInstructorDetailProcedure = "spGetInstructor";
        private const string GetInstructorListProcedure = "spGetInstructorList";

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertInstructorInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@id"].Value = instructor.InstructorId;
                adapter.SelectCommand.Parameters["@first"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last"].Value = instructor.LastName;
                adapter.SelectCommand.Parameters["@title"].Value = instructor.Title;

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

        public void UpdateInstructor(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateInstructorInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor.InstructorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = instructor.LastName;
                adapter.SelectCommand.Parameters["@title"].Value = instructor.Title;

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

        public void DeleteInstructor(string string_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Debug.WriteLine(string_id);
            int id = Convert.ToInt32(string_id);

            try
            {
                var adapter = new SqlDataAdapter(DeletInstructorInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@id"].Value = id;

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

        public Instructor GetInstructorDetail(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Instructor instructor = null;

            try
            {
                var adapter = new SqlDataAdapter(GetInstructorDetailProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                instructor = new Instructor
                {
                    InstructorId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["instructor_id"].ToString()),
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                    Title = dataSet.Tables[0].Rows[0]["title"].ToString(),
                };
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return instructor;
        }

        public List<Instructor> GetInstructorList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var instructorList = new List<Instructor>();

            try
            {
                var adapter = new SqlDataAdapter(GetInstructorListProcedure, conn)
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
                    var instructor = new Instructor
                    {
                        InstructorId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["instructor_id"].ToString()),
                        FirstName = dataSet.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = dataSet.Tables[0].Rows[i]["last_name"].ToString(),
                        Title = dataSet.Tables[0].Rows[i]["title"].ToString(),
                    };
                    instructorList.Add(instructor);
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

            if (instructorList.Count == 0)
            {
                errors.Add("Error: no data returned.");
                return null;
            }
            else
            {
                return instructorList;
            }
        }
    }
}
