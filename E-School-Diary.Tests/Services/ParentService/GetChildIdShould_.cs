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
    public class GetChildIdShould_
    {
        private string searcherId = Guid.NewGuid().ToString();
        private string parentId = Guid.NewGuid().ToString();

        [Test]
        public void ReturnChildId()
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
            var childId = parentService.GetChildId(this.parentId);

            // Assert
            Assert.AreEqual(this.searcherId, childId);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("kiro"),
                new ApplicationUser("pesho"),
                new ApplicationUser("gosho")
            };
            

            users[0].Id = this.searcherId;

            users[1].Id = this.parentId;
            users[1].ChildId = this.searcherId;

            return users;
        }
    }
}
