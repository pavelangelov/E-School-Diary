using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.Admin.AddTeacherToClassPresenterTests
{
    [TestFixture]
    public class View_AddTeacherClickShould_
    {
        [Test]
        public void SetIsSuccessToTrue_IfAllIsDone()
        {
            // Arrange
            var teacher = new User();
            var mockedView = new Mock<IAddTeacherToClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddTeacherToClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Returns(teacher);
            mockedTeacherService.Setup(s => s.Save()).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var presenter = new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, mockedStudentClassService.Object);

            var ev = new AddTeacherToClassEventArgs(null, null);
            // Act
            mockedView.Raise(v => v.AddTeacherClick += null, ev);

            // Assert
            Assert.IsTrue(mockedView.Object.Model.IsSuccess);
            mockedTeacherService.Verify(s => s.Save(), Times.Once);
            mockedStudentClassService.Verify(s => s.FindById(It.IsAny<string>()), Times.Once);
            
        }

        [Test]
        public void SetErrorMessageToViewModel_IfSaveToDbThrows()
        {
            // Arrange
            var expectedMessage = "Something`s wrong.";
            var teacher = new User();
            var mockedView = new Mock<IAddTeacherToClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddTeacherToClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Returns(teacher);
            mockedTeacherService.Setup(s => s.Save()).Throws<Exception>();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var presenter = new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, mockedStudentClassService.Object);

            var ev = new AddTeacherToClassEventArgs(null, null);

            // Act & Assert
            Assert.DoesNotThrow(() => mockedView.Raise(v => v.AddTeacherClick += null, ev));
            Assert.IsFalse(mockedView.Object.Model.IsSuccess);
            Assert.AreEqual(expectedMessage, mockedView.Object.Model.ErrorMessage);
            mockedStudentClassService.Verify(s => s.FindById(It.IsAny<string>()), Times.Once);

        }
    }
}
