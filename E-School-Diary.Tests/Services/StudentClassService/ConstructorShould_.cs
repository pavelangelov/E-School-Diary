using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.StudentClassServiceTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void NotToThrow_IfPassedValueIsValid()
        {
            // Arrange
            var mockDbContext = new Mock<IDatabaseContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new StudentClassService(mockDbContext.Object));
        }

        [Test]
        public void ToThrowArgumentNullException_IfPassedParameterIsNull()
        {
            // Arrange, Act & Assert
            var msg = Assert.Throws<ArgumentNullException>(() => new StudentClassService(null)).Message;
            Assert.IsTrue(msg.Contains("dbContext"));
        }
    }
}
