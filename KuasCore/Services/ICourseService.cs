using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{

    public interface ICourseService
    {


        void AddCourse(Course Course);

        IList<Course> GetAllCourse();

        Course GetCourseByName(string CourseName);
        

    }
}
