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
    public class AddShould_
    {
        [Test]
        public void AddMarkToDatabase()
        {
            // Arrange
            var classes = new List<StudentClass>();
            var queryable = classes.AsQueryable();

            var mockDbSet = new Mock<IDbSet<StudentClass>>();
            mockDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<StudentClass>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<StudentClass>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            mockDbSet.Setup(d => d.Add(It.IsAny<StudentClass>())).Callback<StudentClass>((cl) => classes.Add(cl));

            var mockDbContext = new Mock<IDatabaseContext>();
            mockDbContext.Setup(c => c.StudentClasses).Returns(mockDbSet.Object);

            var studentClassService = new StudentClassService(mockDbContext.Object);
            var studentClass = new StudentClass("1A");

            // Act
            studentClassService.Add(studentClass);

            // Assert
            Assert.IsTrue(classes.Count() == 1);
            Assert.IsTrue(classes.Contains(studentClass));
        }
    }
}
