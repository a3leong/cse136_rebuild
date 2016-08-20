namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class StaffServiceTest
    {
        public Staff CreateStaff()
        {
            var staff = new Staff
            {
                StaffId = 10,
                Email = "super@yahoo.com",
                Password = "techno"
            };
            return staff;
        }

        [TestMethod]
        public void ValidateStaffPassTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStaffRepository>();
            var staffService = new StaffService(mockRepository.Object);

            //// Act
            staffService.InsertStaff(this.CreateStaff(), ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}
