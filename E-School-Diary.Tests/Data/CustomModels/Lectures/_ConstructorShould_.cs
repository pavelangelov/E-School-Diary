using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Data.Enums;

namespace E_School_Diary.Tests.Data.CustomModels.Lectures
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void NotToThrow_AndCreateLectureWithUniqueId_AndMarkedAsAhead()
        {
            var lectureId = Guid.Empty.ToString();

            for (int i = 0; i < 5; i++)
            {
                // Arrange & Act
                var lecture = new Lecture();

                // Assert
                Assert.AreNotEqual(lecture.Id, lectureId);
                Assert.AreEqual(lecture.Status.ToString(), "Ahead"); 

                lectureId = lecture.Id;
            }
        }
        
        [TestCase("")]
        [TestCase("id")]
        public void ThrowArgumentException_WhenPassedTeacherIdParameter_IsNotValid(string invalidTeacherId)
        {
            // Arrange
            var classId = Guid.NewGuid().ToString();
            var title = "Some title";
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(1);
            var subject = Subject.Sport;

            // Act & Assert
            var msg = Assert.Throws<ArgumentException>(() => new Lecture(invalidTeacherId, classId, title, start, end, subject)).Message;

            Assert.IsTrue(msg.Contains("TeacherId"));
        }

        [TestCase("")]
        [TestCase("id")]
        public void ThrowArgumentException_WhenPassedClassIdParameter_IsNotValid(string invalidClassId)
        {
            // Arrange
            var teacherId = Guid.NewGuid().ToString();
            var title = "Some title";
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(1);
            var subject = Subject.Sport;

            // Act & Assert
            var msg = Assert.Throws<ArgumentException>(() => new Lecture(teacherId, invalidClassId, title, start, end, subject)).Message;

            Assert.IsTrue(msg.Contains("ClassId"));
        }

        [TestCase("")]
        [TestCase("i")]
        [TestCase("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        public void ThrowArgumentException_WhenPassedTitleParameter_IsNotValid(string invalidTitle)
        {
            // Arrange
            var teacherId = Guid.NewGuid().ToString();
            var classId = Guid.NewGuid().ToString();
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(1);
            var subject = Subject.Sport;

            // Act & Assert
            var msg = Assert.Throws<ArgumentException>(() => new Lecture(teacherId, classId, invalidTitle, start, end, subject)).Message;

            Assert.IsTrue(msg.Contains("Title"));
        }
    }
}
