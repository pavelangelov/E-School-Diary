using System;

using NUnit.Framework;

using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Factories;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CreateMarkShould_
    {
        [TestCase(Subject.Art, 2)]
        [TestCase(Subject.Biology, 3.5)]
        [TestCase(Subject.Bulgarian, 4.2)]
        [TestCase(Subject.ComputerScience, 5.5)]
        [TestCase(Subject.English, 6)]
        public void NotToThrow_AndCraeteNewMark(Subject subject, double value)
        {
            // Arrange
            var studentId = Guid.NewGuid().ToString();
            var markFactory = new MarkFactory();

            // Act
            var mark = markFactory.CreateMark(studentId, subject, value);

            // Assert
            Assert.AreEqual(studentId, mark.StudentId);
            Assert.AreEqual(subject, mark.Subject);
            Assert.AreEqual(value, mark.Value);
            Assert.AreEqual(typeof(Mark), mark.GetType());
        }
    }
}
