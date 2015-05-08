using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface ICourseDao
    {

        void AddCourse(Course Course);


        IList<Course> GetAllCourse();

        Course GetCourseByName(string CourseName);

    }
}
