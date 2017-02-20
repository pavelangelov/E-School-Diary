using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class SaveShould_
    {
        [Test]
        public void CallDbContext_SaveMethod()
        {
            // Arrange
            var mockedDbContext = new Mock<IDatabaseContext>();
            mockedDbContext.Setup(c => c.Save()).Returns(1).Verifiable();

            var userService = new UserService(mockedDbContext.Object);

            // Act
            var result = userService.Save();

            // Assert
            Assert.IsTrue(result == 1);
            mockedDbContext.Verify(c => c.Save(), Times.Once);
        }
    }
}
