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
                FullName = "Gender Studies2",
                ShorthandName = "GS2",
                Description = "A non-practical major.",
            };
            return major;
        }

        public Major modifyMajor()
        {
            var major = new Major
            {
                Id = 3,
                FullName = "Computer Swag",
                ShorthandName = "CSW",
                Description = "A major",
            };
            return major;
        }
        
        [TestMethod]
        public void WebAPIInsertMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var success = majorController.InsertMajor(createMajor(), ref errors);
            Assert.AreEqual("ok", success);
        }

        [TestMethod]
        public void WebAPIGetMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var major = majorController.GetMajor("CSW", ref errors);
            Assert.AreEqual(major.Id, 3);
            Assert.AreEqual(major.FullName, "Computer Swag");
            Assert.AreEqual(major.ShorthandName, "CSW");
            Assert.AreEqual(major.Description, "A major");
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void WebAPIUpdateMajorSuccessTest()
        {
            var errors = new List<string>();
            var majorController = new MajorController();
            var success = majorController.UpdateMajor(modifyMajor(), ref errors);
            Assert.AreEqual("ok", success);
        }

        [TestMethod]
        public void WebAPIDeleteMajorSuccessTest()
        {
            var errors = new List<String>();
            var majorController = new MajorController();
            var success = majorController.DeleteMajor("7", ref errors);
            for (int i = 0; i < errors.Count; i++)
            {
                System.Console.WriteLine(errors[i]);
            }
            Assert.AreEqual("ok", success);
        }
    }
}
