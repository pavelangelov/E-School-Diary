using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.MarkServiceTests
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
            Assert.DoesNotThrow(() => new MarkService(mockDbContext.Object));
        }

        [Test]
        public void ToThrowArgumentNullException_IfPassedParameterIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new MarkService(null));
        }
    }
}
