using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course Course = new Course();
            Course.CourseID = "UnitTests";
            Course.CourseName = "測試";
            Course.CourseDescription = "測試";
            CourseDao.AddCourse(Course);

            Course dbCourse = CourseDao.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

          //  CourseDao.DeleteCourse(dbCourse);
           // dbCourse = CourseDao.GetCourseByName(Course.CourseName);
           // Assert.IsNull(dbCourse);
        }

     
        [TestMethod]
        public void TestCourseDao_GetCourseByName()
        {
            Course Course = CourseDao.GetCourseByName("ASP.NET");
            Assert.IsNotNull(Course);
            Console.WriteLine("課程編號為 = " + Course.CourseID);
            Console.WriteLine("課程名稱為 = " + Course.CourseName);
            Console.WriteLine("課程描述為 = " + Course.CourseDescription);
        }

    }
}
