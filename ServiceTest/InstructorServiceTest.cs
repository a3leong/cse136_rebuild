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
    public class InstructorServiceTest
    {
        public Instructor createInstructor()
        {
            var instructor = new Instructor
            {
                InstructorId = 4,
                FirstName = "Angelina",
                LastName = "Smith",
                Title = "Researcher"
            };
            return instructor;
        }

        [TestMethod]
        public void ValidateInstructorPassTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            var instructor = createInstructor();

            //// Act
            instructorService.InsertInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}
