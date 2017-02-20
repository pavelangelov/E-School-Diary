using E_School_Diary.Auth;
using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Tests.Services.ParentServiceTests
{
    [TestFixture]
    public class GetChildMarksShould_
    {
        private string searcherId = Guid.NewGuid().ToString();
        private string searchedIdForNullMarks = Guid.NewGuid().ToString();

        [Test]
        public void ReturnEmptyCollection_IfParentIdMatched_AndStudentDoesNotHaveMarks()
        {
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

            var messages = parentService.GetChildMarks(this.searchedIdForNullMarks);

            Assert.IsTrue(messages.Count() == 0);
        }

        [Test]
        public void ReturnCollectionWithMarks_IfParentId_MatchedAndStudentHasMarks()
        {
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

            var messages = parentService.GetChildMarks(this.searcherId);

            Assert.IsTrue(messages.Count() == 1);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser("kiro"),
                new ApplicationUser("pesho"),
                new ApplicationUser("gosho")
            };

            var childId = Guid.NewGuid().ToString();

            users[0].Id = childId;
            users[0].Marks.Add(new Mark() { StudentId = childId, Value = 5});

            users[1].Id = this.searcherId;
            users[1].ChildId = childId;

            users[2].Id = this.searchedIdForNullMarks;
            users[2].ChildId = users[1].Id;

            return users;
        }
    }
}
