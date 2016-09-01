namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using IRepository;
    using POCO;

    public class MajorRepository : BaseRepository, IMajorRepository
    {
        private const string InsertMajorInfoProcedure = "spInsertMajorInfo";
        private const string UpdateMajorInfoProcedure = "spUpdateMajorInfo";
        private const string DeleteMajorInfoProcedure = "spDeleteMajorInfo";
        private const string GetMajorDetailProcedure = "spGetMajorInfo";
        private const string GetMajorListProcedure = "spGetMajorList";
        private const string GetMajorRequirementsListProcedure = "spGetMajorRequirementsList";
        private const string InsertMajorRequirementsProcedure = "spInsertRequirementInfo";
        private const string DeleteMajorRequirementsProcedure = "spDeleteRequirementsInfo";

        public void InsertMajor(Major major, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertMajorInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@full_name", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shorthand_name", SqlDbType.VarChar, 5));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar, 500));

                adapter.SelectCommand.Parameters["@full_name"].Value = major.FullName;
                adapter.SelectCommand.Parameters["@shorthand_name"].Value = major.ShorthandName;
                adapter.SelectCommand.Parameters["@description"].Value = major.Description;

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

        public void UpdateMajor(Major major, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateMajorInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@full_name", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shorthand_name", SqlDbType.VarChar, 5));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar, 500));

                adapter.SelectCommand.Parameters["@id"].Value = major.Id;
                adapter.SelectCommand.Parameters["@full_name"].Value = major.FullName;
                adapter.SelectCommand.Parameters["@shorthand_name"].Value = major.ShorthandName;
                adapter.SelectCommand.Parameters["@description"].Value = major.Description;

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

        public void DeleteMajor(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteMajorInfoProcedure, conn)
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

        public Major GetMajorDetail(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Major major = null;

            try
            {
                var adapter = new SqlDataAdapter(GetMajorDetailProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = Convert.ToInt32(id);

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                major = new Major
                {
                    Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["id"].ToString()),
                    FullName = dataSet.Tables[0].Rows[0]["full_name"].ToString(),
                    ShorthandName = dataSet.Tables[0].Rows[0]["shorthand_name"].ToString(),
                    Description = dataSet.Tables[0].Rows[0]["description"].ToString(),
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

            return major;
        }

        public List<Major> GetMajorList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var majorList = new List<Major>();

            try
            {
                var adapter = new SqlDataAdapter(GetMajorListProcedure, conn)
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
                    var major = new Major
                    {
                        Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["id"].ToString()),
                        FullName = dataSet.Tables[0].Rows[i]["full_name"].ToString(),
                        ShorthandName = dataSet.Tables[0].Rows[i]["shorthand_name"].ToString(),
                        Description = dataSet.Tables[0].Rows[i]["description"].ToString(),
                    };
                    majorList.Add(major);
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

            return majorList;
        }


        public List<Course> GetMajorRequirements(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetMajorRequirementsListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = Convert.ToInt32(id); ;


                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var course = new Course
                    {
                        CourseId = dataSet.Tables[0].Rows[i]["course_id"].ToString(),
                        Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        CourseLevel =
                            (CourseLevel)
                            Enum.Parse(
                                typeof(CourseLevel),
                                dataSet.Tables[0].Rows[i]["course_level"].ToString()),
                        Description = dataSet.Tables[0].Rows[i]["course_description"].ToString()
                    };
                    courseList.Add(course);
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

            return courseList;
        }

        public void InsertRequirement(string major_id, string course_id, ref List<string> errors)
        {
            int m_id = Convert.ToInt32(major_id);
            int c_id = Convert.ToInt32(course_id);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertMajorRequirementsProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@major_id"].Value = m_id;
                adapter.SelectCommand.Parameters["@course_id"].Value = c_id;

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

        public void DeleteRequirement(string major_id, string course_id, ref List<string> errors) 
        {
            int m_id = Convert.ToInt32(major_id);
            int c_id = Convert.ToInt32(course_id);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteMajorRequirementsProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@major_id"].Value = m_id;
                adapter.SelectCommand.Parameters["@course_id"].Value = c_id;

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
