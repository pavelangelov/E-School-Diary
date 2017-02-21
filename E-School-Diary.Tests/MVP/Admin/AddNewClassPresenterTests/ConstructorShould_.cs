using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.AdminPresenters.AddNewClassPresenterTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfStudentClassService_IsNull()
        {
            // Arrange
            var mockedView = new Mock<IAddNewClassView>();
            var mockedTeacherService = new Mock<ITeacherService>();
            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new AddNewClassPresenter(mockedView.Object, null, mockedTeacherService.Object, mockedStudentClassFactory.Object)).Message;
            Assert.IsTrue(message.Contains("studentClassService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfTeacherService_IsNull()
        {
            // Arrange
            var mockedView = new Mock<IAddNewClassView>();
            var mockedStudentClassService = new Mock<IStudentClassService>();
            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, null, mockedStudentClassFactory.Object)).Message;
            Assert.IsTrue(message.Contains("teacherService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfStudentClassFactory_IsNull()
        {
            // Arrange
            var mockedView = new Mock<IAddNewClassView>();
            var mockedStudentClassService = new Mock<IStudentClassService>();
            var mockedTeacherService = new Mock<ITeacherService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, null)).Message;
            Assert.IsTrue(message.Contains("studentClassFactory"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            // Arrange
            var mockedView = new Mock<IAddNewClassView>();
            var mockedStudentClassService = new Mock<IStudentClassService>();
            var mockedTeacherService = new Mock<ITeacherService>();
            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();

            // Act & Assert
            Assert.DoesNotThrow(() => new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object));
        }
    }
}
