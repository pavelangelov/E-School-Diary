using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Tests.Data.CustomModels.StudentClasses
{
    [TestFixture]
    public class _FormMasterIdShoul_
    {
        [TestCase("")]
        [TestCase("A")]
        public void ThrowArgumentException_WhenParameterIsInvalid(string invalidTeacherId)
        {
            var stClass = new StudentClass();

            var msg = Assert.Throws<ArgumentException>(() => stClass.FormMasterId = invalidTeacherId).Message;
            Assert.IsTrue(msg.Contains("FormMasterId"));
        }
        
        [Test]
        public void NotToThrow_AndSetParameter()
        {
            var stClass = new StudentClass();
            var formMasterId = Guid.NewGuid().ToString();

            stClass.FormMasterId = formMasterId;

            Assert.AreEqual(formMasterId, stClass.FormMasterId);
        }
    }
}
