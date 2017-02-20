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
    public class GetMinInfoShould_
    {
        [Test]
        public void ReturnCorrecrResult_IfIdMatched()
        {
            // Arrange
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser() {FirstName = "Pesho", MiddleName = "P.", LastName="Peshev", UserName="pesho", ImageUrl="no image" },
                new ApplicationUser() {FirstName = "Gosho", MiddleName = "P.", LastName="Goshev", UserName="gosho", ImageUrl="no image" },
                new ApplicationUser() {FirstName = "Kiro", MiddleName = "P.", LastName="Kirov", UserName="kiro", ImageUrl="no image" }
            };
            var searchedId = Guid.NewGuid().ToString();
            users[1].Id = searchedId;
            var queryable = users.AsQueryable();

            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Users).Returns(mockedDbSet.Object);

            var userService = new UserService(mockedDbContext.Object);

            // Act
            var userInfo = userService.GetMinInfo(searchedId);

            // Assert
            Assert.AreEqual(users[1].UserName, userInfo.Username);
            Assert.AreEqual(users[1].FirstName, userInfo.FirstName);
            Assert.AreEqual(users[1].MiddleName, userInfo.MiddleName);
            Assert.AreEqual(users[1].LastName, userInfo.LastName);
        }

        [Test]
        public void ReturnNull_IfIdNotMatched()
        {
            // Arrange
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser() {FirstName = "Pesho", MiddleName = "P.", LastName="Peshev", UserName="pesho", ImageUrl="no image" },
                new ApplicationUser() {FirstName = "Gosho", MiddleName = "P.", LastName="Goshev", UserName="gosho", ImageUrl="no image" },
                new ApplicationUser() {FirstName = "Kiro", MiddleName = "P.", LastName="Kirov", UserName="kiro", ImageUrl="no image" }
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
            var searchedId = Guid.NewGuid().ToString();

            // Act
            var userInfo = userService.GetMinInfo(searchedId);

            // Assert
            Assert.IsNull(userInfo);
        }
    }
}
