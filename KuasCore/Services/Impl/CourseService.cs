using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddCourse(Course Course)
        {
            CourseDao.AddCourse(Course);
        }

        public IList<Course>GetAllCourse()
        {
            return CourseDao.GetAllCourse();
        }


        public Course GetCourseByName(string CourseName)
        {
            return CourseDao.GetCourseByName(CourseName);
        }



    }

}
