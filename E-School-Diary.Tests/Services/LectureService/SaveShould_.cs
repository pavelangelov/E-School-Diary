using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.LectureServiceTests
{
    [TestFixture]
    public class SaveShould_
    {
        [Test]
        public void CallDAtabaseContext_SaveMethod()
        {
            var mockDbContext = new Mock<IDatabaseContext>();
            mockDbContext.Setup(c => c.Save()).Returns(1).Verifiable();

            var lectureService = new LectureService(mockDbContext.Object);

            var result = lectureService.Save();

            Assert.AreEqual(1, result);
            mockDbContext.Verify(c => c.Save(), Times.Once);
        }
    }
}
