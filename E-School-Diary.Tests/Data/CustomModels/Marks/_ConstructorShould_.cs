using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Data.Enums;

namespace E_School_Diary.Tests.Data.CustomModels.Marks
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void NotToThrow_AndCreateMarkWithUniqueId()
        {
            var markId = Guid.Empty.ToString();

            for (int i = 0; i < 5; i++)
            {
                // Arrange & Act
                var mark = new Mark();

                // Assert
                Assert.AreNotEqual(mark.Id, markId);

                markId = mark.Id;
            }
        }

        [TestCase("")]
        [TestCase("id")]
        public void ThrowArgumentException_WhenPassedStudentIdParameter_IsNotValid(string invalidStudentId)
        {
            // Arrange
            var subject = Subject.Sport;
            var value = 4;

            // Act & Assert
            var msg = Assert.Throws<ArgumentException>(() => new Mark(invalidStudentId, subject, value)).Message;

            Assert.IsTrue(msg.Contains("StudentId"));
        }

        [TestCase(1.9)]
        [TestCase(6.1)]
        public void ThrowArgumentException_WhenPassedValueParameter_IsNotValid(double invalidValue)
        {
            // Arrange
            var subject = Subject.Sport;
            var studentId = Guid.NewGuid().ToString();

            // Act & Assert
            var msg = Assert.Throws<ArgumentException>(() => new Mark(studentId, subject, invalidValue)).Message;

            Assert.IsTrue(msg.Contains("Value"));
        }

        [TestCase(Subject.Art, 2)]
        [TestCase(Subject.Biology, 4)]
        [TestCase(Subject.Bulgarian, 5.5)]
        [TestCase(Subject.English, 6)]
        public void NotToThrow_WhenPassedParameters_AreValid_AndSetCorrectlly(Subject subject, double value)
        {
            // Arrange
            var studentId = Guid.NewGuid().ToString();

            // Act & Assert
            var mark = new Mark(studentId, subject, value);

            Assert.AreEqual(studentId, mark.StudentId);
            Assert.AreEqual(subject, mark.Subject);
            Assert.AreEqual(value, mark.Value);
        }
    }
}
