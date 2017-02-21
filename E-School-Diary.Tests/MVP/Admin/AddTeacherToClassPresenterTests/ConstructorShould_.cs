using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.Admin.AddTeacherToClassPresenterTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfStudentClassService_IsNull()
        {
            // Arrange
            var mockedView = new Mock<IAddTeacherToClassView>();
            var mockedTeacherService = new Mock<ITeacherService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, null)).Message;
            Assert.IsTrue(message.Contains("studentClassService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfTeacherService_IsNull()
        {
            // Arrange
            var mockedView = new Mock<IAddTeacherToClassView>();
            var mockedStudentClassService = new Mock<IStudentClassService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new AddTeacherToClassPresenter(mockedView.Object, null, mockedStudentClassService.Object)).Message;
            Assert.IsTrue(message.Contains("teacherService"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            // Arrange
            var mockedView = new Mock<IAddTeacherToClassView>();
            var mockedStudentClassService = new Mock<IStudentClassService>();
            var mockedTeacherService = new Mock<ITeacherService>();

            // Act & Assert
            Assert.DoesNotThrow(() => new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, mockedStudentClassService.Object));
        }
    }
}
