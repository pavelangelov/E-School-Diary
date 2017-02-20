using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.StudentClassServiceTests
{
    [TestFixture]
    public class FindByTeacherIdShould_
    {
        [Test]
        public void ShouldReturnClass_IfTeacherIdMatched()
        {
            // Arrange
            var teacherId = Guid.NewGuid().ToString();
            var classes = new List<StudentClass>()
            {
                new StudentClass("1A"),
                new StudentClass("2A") {FormMasterId = teacherId },
                new StudentClass("3A")
            };
            var queryable = classes.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<StudentClass>>();
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.StudentClasses).Returns(mockedDbSet.Object);

            var studentClassService = new StudentClassService(mockedDbContext.Object);

            // Act
            var cl = studentClassService.FindByTeacherId(teacherId);

            // Assert
            Assert.AreEqual(classes[1], cl);
            Assert.AreEqual(classes[1].FormMasterId, teacherId);
        }

        [Test]
        public void ShouldReturnNull_IfTeacherIdNotMatched()
        {
            // Arrange
            var teacherId = Guid.NewGuid().ToString();
            var classes = new List<StudentClass>()
            {
                new StudentClass("1A"),
                new StudentClass("2A"),
                new StudentClass("3A")
            };
            var queryable = classes.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<StudentClass>>();
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.StudentClasses).Returns(mockedDbSet.Object);

            var studentClassService = new StudentClassService(mockedDbContext.Object);

            // Act
            var cl = studentClassService.FindByTeacherId(teacherId);

            // Assert
            Assert.IsNull(cl);
        }
    }
}
