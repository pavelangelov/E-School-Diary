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
    public class GetParentMessagesShould_
    {
        private string searcherId = Guid.NewGuid().ToString();
        private string seracherMessageContent = "Test completed!";

        [Test]
        public void ReturnNull_IfIdNotMatch()
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
            var searcheParentdId = Guid.NewGuid().ToString();

            // Act
            var messages = parentService.GetParentMessages(searcheParentdId);

            // Assert
            Assert.IsTrue(messages== null);
        }

        [Test]
        public void ReturnParentMessages_IfIdMathed()
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
            var messages = parentService.GetParentMessages(this.searcherId);

            // Assert
            Assert.IsTrue(messages.Count() == 1);
            Assert.IsTrue(messages.First().Content == this.seracherMessageContent);

        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("pesho"),
                new ApplicationUser("kiro"),
                new ApplicationUser("miro")
            };

            users[1].Id = this.searcherId;
            users[1].Messages.Add(new Message() { Content = this.seracherMessageContent });

            return users;
        }
    }
}
