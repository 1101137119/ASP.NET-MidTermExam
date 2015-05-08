using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class CourseController : ApiController
    {
        public ICourseService CourseService { get; set; }

        [HttpGet]
        public IList<Course> GetAllCourse()
        {
            return CourseService.GetAllCourse();
        }

        [HttpGet]
                [ActionName("byName")]
        public Course GetCourseByName(string CourseName)
                {
                    var Course = CourseService.GetCourseByName(CourseName);

                    if (Course == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    return Course;
                }

    }
}
