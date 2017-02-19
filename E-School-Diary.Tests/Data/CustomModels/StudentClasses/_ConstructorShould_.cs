using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Tests.Data.CustomModels.StudentClasses
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void NotToThrow_AndCreateClassWith_UniqueId()
        {
            var classId = Guid.Empty.ToString();
            for (int i = 0; i < 5; i++)
            {
                var cl = new StudentClass();

                Assert.AreNotEqual(classId, cl.Id);
                Assert.IsNotNull(cl.Lectures);
                Assert.IsNotNull(cl.Students);

                classId = cl.Id;
            }
        }

        [TestCase("1A")]
        [TestCase("1a")]
        [TestCase("12A")]
        [TestCase("12C")]
        public void NotToThrow_AndCreateClassWith_UniqueIdAndSetName(string validName)
        {
            var classId = Guid.Empty.ToString();
            for (int i = 0; i < 5; i++)
            {
                var cl = new StudentClass(validName);

                Assert.AreNotEqual(classId, cl.Id);
                Assert.AreEqual(validName, cl.Name);
                Assert.IsNotNull(cl.Lectures);
                Assert.IsNotNull(cl.Students);

                classId = cl.Id;
            }
        }

        [TestCase("")]
        [TestCase("1")]
        [TestCase("First A")]
        public void ThrowArgumentException_WhenPassedNameParameter_IsNotValid(string invalidName)
        {
            var msg = Assert.Throws<ArgumentException>(() => new StudentClass(invalidName)).Message;
            Assert.IsTrue(msg.Contains("Name"));
        }
    }
}
