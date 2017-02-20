using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.ParentServiceTests
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

            var parentService = new ParentService(mockedDbContext.Object);

            // Act
            var result = parentService.Save();

            // Assert
            Assert.IsTrue(result == 1);
            mockedDbContext.Verify(c => c.Save(), Times.Once);
        }
    }
}
