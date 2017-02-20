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

namespace E_School_Diary.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class FindByIdShould_
    {
        [Test]
        public void ReturnCorrectResult_IfIdMatched()
        {
            // Arrange
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("pesho"),
                new ApplicationUser("pesho"),
                new ApplicationUser("pesho")
            };
            var queryable = users.AsQueryable();
            var seracherId = Guid.NewGuid().ToString();
            users[1].Id = seracherId;

            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Users).Returns(mockedDbSet.Object);

            var userService = new UserService(mockedDbContext.Object);

            // Act
            var user = userService.FindById(seracherId);

            // Assert
            Assert.AreEqual(users[1], user);
        }

        [Test]
        public void ReturnNull_IfIdNotMatched()
        {
            // Arrange
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("pesho"),
                new ApplicationUser("pesho"),
                new ApplicationUser("pesho")
            };
            var queryable = users.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Users).Returns(mockedDbSet.Object);

            var userService = new UserService(mockedDbContext.Object);
            var seracherId = Guid.NewGuid().ToString();

            // Act
            var user = userService.FindById(seracherId);

            // Assert
            Assert.IsNull(user);
        }
    }
}
