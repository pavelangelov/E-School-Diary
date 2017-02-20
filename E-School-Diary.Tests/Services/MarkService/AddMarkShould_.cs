using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.MarkServiceTests
{
    [TestFixture]
    public class AddMarkShould_
    {
        [Test]
        public void AddMarkToDatabase()
        {
            // Arrange
            var marks = new List<Mark>();
            var queryable = marks.AsQueryable();

            var mockDbSet = new Mock<IDbSet<Mark>>();
            mockDbSet.As<IQueryable<Mark>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<Mark>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<Mark>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<Mark>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            mockDbSet.Setup(d => d.Add(It.IsAny<Mark>())).Callback<Mark>((m) => marks.Add(m));

            var mockDbContext = new Mock<IDatabaseContext>();
            mockDbContext.Setup(c => c.Marks).Returns(mockDbSet.Object);

            var markService = new MarkService(mockDbContext.Object);
            var mark = new Mark();

            // Act
            markService.Add(mark);

            // Assert
            Assert.IsTrue(marks.Count() == 1);
            Assert.IsTrue(marks.Contains(mark));
        }
    }
}
