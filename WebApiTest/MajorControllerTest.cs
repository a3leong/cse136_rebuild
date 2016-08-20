using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCO;
using WebApi.Controllers;
using System.Collections.Generic;

namespace WebApiTest
{
    [TestClass]
    public class MajorControllerTest
    {

        public Major createMajor()
        {
            var major = new Major
            {
                Id = 1,
                FullName = "Computer Science and Engineering",
                ShorthandName = "CSE",
                Description = "A major for people who want to be computer programmers and engineers.",
            };
            return major;
        }

        public Major modifyMajor()
        {
            var major = new Major
            {
                Id = 1,
                FullName = "Computer Science and Engineering!",
                ShorthandName = "CSE",
                Description = "A major for people who want to be computer programmers and engineers!",
            };
            return major;
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var success = majorController.InsertMajor(createMajor(), ref errors);
            Assert.AreEqual("ok", success);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var major = majorController.GetMajor("1", ref errors);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatetMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var success = majorController.UpdateMajor(modifyMajor(), ref errors);
            Assert.AreEqual("ok", success);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteMajorSuccessTest()
        {

            var majorController = new MajorController();
            var success = majorController.DeleteMajor("1");
            Assert.AreEqual("ok", success);
        }
    }
}
