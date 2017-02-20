using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.MarkServiceTests
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

            var markService = new MarkService(mockedDbContext.Object);

            // Act
            var result = markService.Save();

            // Assert
            Assert.IsTrue(result == 1);
            mockedDbContext.Verify(c => c.Save(), Times.Once);
        }
    }
}
