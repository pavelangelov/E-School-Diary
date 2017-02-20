using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Auth;
using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.ParentServiceTests
{
    [TestFixture]
    public class FindParentsShould_
    {
        private string studentId = Guid.NewGuid().ToString();
        private string studentWithoutParents = Guid.NewGuid().ToString();

        [Test]
        public void ReturnCollectionWithParents_IfStudentHasParents()
        {
            // Arrange
            var users = this.GetUsers();
            var queryable = users.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Users).Returns(mockedDbSet.Object);

            var parentService = new ParentService(mockedDbContext.Object);

            // Act
            var parents = parentService.FindParents(this.studentId);

            // Assert
            Assert.IsTrue(parents.Count() == 1);
        }

        [Test]
        public void ReturnEmptyCollection_IfStudentDoesNotHaveParents()
        {
            // Arrange
            var users = this.GetUsers();
            var queryable = users.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Users).Returns(mockedDbSet.Object);

            var parentService = new ParentService(mockedDbContext.Object);

            // Act
            var parents = parentService.FindParents(this.studentWithoutParents);

            // Assert
            Assert.IsTrue(parents.Count() == 0);
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("kiro"),
                new ApplicationUser("pesho"),
                new ApplicationUser("misho")
            };

            users[1].Id = this.studentId;
            users[1].Parents.Add(new User());

            users[2].Id = this.studentWithoutParents;

            return users;
        }
    }
}
