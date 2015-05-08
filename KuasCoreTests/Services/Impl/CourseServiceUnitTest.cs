using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course Course = new Course();
            Course.CourseID = "UnitTests";
            Course.CourseName = "單元測試";
            Course.CourseDescription = "TEST";
            CourseService.AddCourse(Course);

            Course dbCourse = CourseService.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, Course.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseID);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

         //   CourseService.DeleteCourse(dbCourse);
         //   dbCourse = CourseService.GetCourseByName(Course.CourseName);
         //   Assert.IsNull(dbCourse);
        }

     /*
        [TestMethod]
        public void TestEmployeeService_DeleteEmployee()
        {
            Employee newEmpolyee = new Employee();
            newEmpolyee.Id = "UnitTests";
            newEmpolyee.Name = "單元測試";
            newEmpolyee.Age = 15;
            EmployeeService.AddEmployee(newEmpolyee);

            Employee dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
            Assert.IsNotNull(dbEmpolyee);

            EmployeeService.DeleteEmployee(dbEmpolyee);
            dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
            Assert.IsNull(dbEmpolyee);
        }
        */
        [TestMethod]
        public void TestCourseService_GetCourseByName()
        {
            Course Course = CourseService.GetCourseByName("ASP.NET");
            Assert.IsNotNull(Course);

            Console.WriteLine("員工編號為 = " + Course.CourseID);
            Console.WriteLine("員工姓名為 = " + Course.CourseName);
            Console.WriteLine("員工年齡為 = " + Course.CourseDescription);
        }

    }
}
