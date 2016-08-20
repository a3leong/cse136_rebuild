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
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@decription", SqlDbType.VarChar, 500));

                adapter.SelectCommand.Parameters["@full_name"].Value = major.FullName;
                adapter.SelectCommand.Parameters["@display_name"].Value = major.ShorthandName;
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

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@full_name", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shorthand_name", SqlDbType.VarChar, 5));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@decription", SqlDbType.VarChar, 500));

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

        public void DeleteMajor(string shorthand_id, ref List<string> errors)
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
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shorthand_name", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@shorthand_name"].Value = shorthand_id;

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

        public Major GetMajorDetail(string shorthand_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Major major = null;

            try
            {
                var adapter = new SqlDataAdapter(GetMajorDetailProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shorthand_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@shorthand_id"].Value = shorthand_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                major = new Major
                {
                    Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["id"].ToString()),
                    FullName = dataSet.Tables[0].Rows[0]["name"].ToString(),
                    ShorthandName = dataSet.Tables[0].Rows[0]["display_name"].ToString(),
                    Description = dataSet.Tables[0].Rows[0]["description"].ToString(),
                };

                if (dataSet.Tables[1] != null)
                {
                    major.CourseRequirements = new List<Course>();
                    for (var i = 0; i < dataSet.Tables[1].Rows.Count; i++)
                    {
                        var course = new Course
                        {
                            CourseId = dataSet.Tables[1].Rows[i]["course_id"].ToString(),
                            Title = dataSet.Tables[1].Rows[i]["course_title"].ToString(),
                            Description =
                                dataSet.Tables[1].Rows[i]["course_description"].ToString()
                        };
                        major.CourseRequirements.Add(course);
                    }
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
                        FullName = dataSet.Tables[0].Rows[i]["name"].ToString(),
                        ShorthandName = dataSet.Tables[0].Rows[i]["display_name"].ToString(),
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
    }
}
