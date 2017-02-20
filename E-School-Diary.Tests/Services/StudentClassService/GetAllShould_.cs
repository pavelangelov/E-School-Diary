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
    public class GetAllShould_
    {
        [Test]
        public void ReturnAllClasses()
        {
            // Arrange
            var classes = new List<StudentClass>()
            {
                new StudentClass("1A"),
                new StudentClass("2A"),
                new StudentClass("3A")
            }.AsQueryable();
            

            var mockedDbSet = new Mock<IDbSet<StudentClass>>();
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Provider).Returns(classes.Provider);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.Expression).Returns(classes.Expression);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.ElementType).Returns(classes.ElementType);
            mockedDbSet.As<IQueryable<StudentClass>>().Setup(m => m.GetEnumerator()).Returns(() => classes.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.StudentClasses).Returns(mockedDbSet.Object);

            var studentClassService = new StudentClassService(mockedDbContext.Object);

            // Act
            var allClasses = studentClassService.GetAll().ToList();

            // Assert
            CollectionAssert.AreEqual(classes, allClasses);
        }
    }
}
