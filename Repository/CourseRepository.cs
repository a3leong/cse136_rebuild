namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;

    using IRepository;

    using POCO;

    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private const string InsertCourseInfoProcedure = "spInsertCourseInfo";
        private const string UpdateCourseInfoProcedure = "spUpdateCoursesInfo";
        private const string DeletCourseInfoProcedure = "spDeleteCourseInfo";
        private const string GetCourseDetailProcedure = "spGetCourseInfo";
        private const string GetCourseListProcedure = "spGetCourseList";
        private const string GetFinishedCoursesProcedure = "spGetFinishedCoursesByStudent";
        private const string GetUnfinishedCoursesProcedure = "spGetUnfinishedCoursesByStudent";
        private const string InsertPrereqProcedure = "spInsertPrereqInfo";
        private const string DeletePrereqProcedure = "spDeletePrereqsInfo";
        private const string GetPrereqsListProcedure = "spGetPrereqList";

        public void InsertCourse(Course course, ref List<string> errors)
        {
            int id = Convert.ToInt32(course.CourseId);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertCourseInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar, 8000));

                adapter.SelectCommand.Parameters["@id"].Value = id;
                adapter.SelectCommand.Parameters["@title"].Value = course.Title;
                adapter.SelectCommand.Parameters["@level"].Value = course.CourseLevel;
                adapter.SelectCommand.Parameters["@description"].Value = course.Description;

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

        public void UpdateCourse(Course course, ref List<string> errors)
        {
            int id = Convert.ToInt32(course.CourseId);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCourseInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, 8000));

                adapter.SelectCommand.Parameters["@course_id"].Value = id;
                adapter.SelectCommand.Parameters["@course_title"].Value = course.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = course.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = course.Description;

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

        public void DeleteCourse(string string_id, ref List<string> errors)
        {
            int id = Convert.ToInt32(string_id);

            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeletCourseInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = id;

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

        public Course GetCourseDetails(string string_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Course course = null;

            int id = Convert.ToInt32(string_id);

            try
            {
                var adapter = new SqlDataAdapter(GetCourseDetailProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                course = new Course
                {
                    CourseId = dataSet.Tables[0].Rows[0]["course_id"].ToString(),
                    Title = dataSet.Tables[0].Rows[0]["course_title"].ToString(),
                    CourseLevel =
                        (CourseLevel)
                        Enum.Parse(
                            typeof(CourseLevel),
                            dataSet.Tables[0].Rows[0]["course_level"].ToString()),
                    Description = dataSet.Tables[0].Rows[0]["course_description"].ToString()
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

            return course;
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseListProcedure, conn)
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

        public List<Course> GetFinishedCoursesByStudent(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetFinishedCoursesProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters["@student_id"].Value = id;

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
        

        public List<Course> GetUnfinishedCoursesByStudent(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetUnfinishedCoursesProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters["@student_id"].Value = id;

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

        public void InsertPrereq(string course_id, string prereq_id, ref List<string> errors)
        {
            int c_id = Convert.ToInt32(course_id);
            int p_id = Convert.ToInt32(prereq_id);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertPrereqProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prereq_id", SqlDbType.Int));
   

                adapter.SelectCommand.Parameters["@course_id"].Value = c_id;
                adapter.SelectCommand.Parameters["@prereq_id"].Value = p_id;

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

        public void DeletePrereq(string course_id, string prereq_id, ref List<string> errors)
        {
            int c_id = Convert.ToInt32(course_id);
            int p_id = Convert.ToInt32(prereq_id);
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeletePrereqProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prereq_id", SqlDbType.Int));


                adapter.SelectCommand.Parameters["@course_id"].Value = c_id;
                adapter.SelectCommand.Parameters["@prereq_id"].Value = p_id;

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

        public List<Course> GetPrereqs(string course_id, ref List<string> errors)
        {
            int id = Convert.ToInt32(course_id);
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetPrereqsListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@course_id"].Value = id;

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

    }
}
