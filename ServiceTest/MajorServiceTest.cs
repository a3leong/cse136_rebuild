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
    public class MajorServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertStudentErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentRepository>();
            var studentService = new StudentService(mockRepository.Object);

            //// Act
            studentService.InsertStudent(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrortNullObjectTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            majorService.InsertMajor(null, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorNameEmptyStringTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major { 
                                    FullName = string.Empty,
                                    ShorthandName = "CSE",
                                    Description = "Jacob's school of engineering"  
                                  };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorNameTooLongTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD",
                ShorthandName = "CSE",
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorNameIllegalCharsTest()
        {  
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "?#@$",
                ShorthandName = "CSE",
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorShorthandNameNotAllCapsTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "cse",
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorShorthandNamEmptyStringTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = string.Empty,
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorShorthandNameTooLongTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "CSEE",
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorShorthandNameInvalidCharTest()
        {   
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "CS?",
                Description = "Jacob's school of engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertMajorErrorDescriptionTooLongTest()
        {
            string description = "";
            for (int i = 0; i < 501; i++)
            {
                description = description + "a";
            }

            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "CSE",
                Description = description
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void InsertMajorSuccess()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "CSE",
                Description = "Jacob's School of Engineering"
            };
            majorService.InsertMajor(major, ref errors);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void UpdateMajorSuccess()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "CSE",
                Description = "Jacob's School of Engineering"
            };
            majorService.UpdateMajor(major, ref errors);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateMajorError()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            var major = new Major
            {
                FullName = "Computer Science",
                ShorthandName = "cse",
                Description = "Jacob's School of Engineering"
            };
            majorService.UpdateMajor(major, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMajorError()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            majorService.GetMajor(null, ref errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteMajorError()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IMajorRepository>();
            var majorService = new MajorService(mockRepository.Object);
            majorService.DeleteMajor(null, ref errors);

            Assert.AreEqual(1, errors.Count);
        }
    }
}
