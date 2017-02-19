using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Factories;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CreateClassShould_
    {
        [TestCase("1A")]
        [TestCase("1a")]
        [TestCase("12A")]
        [TestCase("12a")]
        public void NotToThrow_AndCreateNewStudentClass(string className)
        {
            // Arange
            var teacherId = Guid.NewGuid().ToString();
            var studentClassFactory = new StudentClassFactory();

            // Act
            var studentClass = studentClassFactory.CreateClass(className, teacherId);

            // Assert
            Assert.AreEqual(className, studentClass.Name);
            Assert.AreEqual(teacherId, studentClass.FormMasterId);
            Assert.AreEqual(typeof(StudentClass), studentClass.GetType());
        }
    }
}
