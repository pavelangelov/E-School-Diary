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
    public class FindByIdShould_
    {
        private string searcherId = Guid.NewGuid().ToString();

        [Test]
        public void ReturnStudentClass_IfIdMatched()
        {
            // Arrange
            var classes = this.GetClasses();
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
            var cl = studentClassService.FindById(this.searcherId);

            // Assert
            Assert.IsNotNull(cl);
            Assert.AreEqual(this.searcherId, cl.Id);
        }

        [Test]
        public void ReturnNull_IfIdNotMatched()
        {
            // Arrange
            var classes = this.GetClasses();
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
            var id = Guid.NewGuid().ToString();
            var cl = studentClassService.FindById(id);

            // Assert
            Assert.IsNull(cl);
        }

        public IEnumerable<StudentClass> GetClasses()
        {
            var classes = new List<StudentClass>()
            {
                new StudentClass("1A"),
                new StudentClass("2A"),
                new StudentClass("3A")
            };

            classes[1].Id = this.searcherId;

            return classes;
        }
    }
}
