
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course Course)
        {
            string command = @"INSERT INTO Course (CourseID,CourseName,CourseDescription) VALUES (@CourseId, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = Course.CourseID;
            parameters.Add("CourseName", DbType.String).Value = Course.CourseName;
            parameters.Add("CourseDescription", DbType.Int32).Value = Course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }


        public IList<Course> GetAllCourse()
        {
            string command = @"SELECT * FROM Course ORDER BY Id ASC";
            IList<Course> Course = ExecuteQueryWithRowMapper(command);
            return Course;
        }


        public Course GetCourseByName(string CourseName)
        {
            string command = @"SELECT * FROM Course WHERE CourseName = @CourseName";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseName", DbType.String).Value = CourseName;

            IList<Course> Course = ExecuteQueryWithRowMapper(command, parameters);
            if (Course.Count > 0)
            {
                return Course[0];
            }

            return null;
        }


    }
}
