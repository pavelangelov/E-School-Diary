using E_School_Diary.Data.Models;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Tests.MVP.Admin.AddNewClassPresenterTests
{
    [TestFixture]
    public class View_CreateClassClick_Should
    {
        [Test]
        public void SetErrorMessageInViewModel_IfFactoryThrows()
        {
            // Arrange
            var errorMessage = "Test completed!";
            var mockedView = new Mock<IAddNewClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddNewClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.Save()).Verifiable();
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.Add(It.IsAny<StudentClass>())).Verifiable();

            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();
            mockedStudentClassFactory.Setup(f => f.CreateClass(It.IsAny<string>(), It.IsAny<string>())).Throws(new ArgumentException(message: errorMessage));

            var presenter = new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object);
            var ev = new AddNewClassEventArgs(null, null);

            // Act & Assert
            Assert.DoesNotThrow(() => mockedView.Raise(v => v.CreateClassClick += null, ev));
            Assert.AreEqual(errorMessage, mockedView.Object.Model.ErrorMessage);
            Assert.IsFalse(mockedView.Object.Model.IsSuccess);

            // Verify that the method is stopped and other dependencies are not called
            mockedTeacherService.Verify(s => s.Save(), Times.Never);
            mockedTeacherService.Verify(s => s.FindById(It.IsAny<string>()), Times.Never);

            mockedStudentClassService.Verify(s => s.Add(It.IsAny<StudentClass>()), Times.Never);
        }


        [Test]
        public void SetErrorMessageInViewModel_IfStudentClassServiceThrows()
        {
            // Arrange
            var expectedMessge = "Something`s wrong. Maybe this class already exist."; ;

            var mockedView = new Mock<IAddNewClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddNewClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.Save()).Verifiable();
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.Add(It.IsAny<StudentClass>())).Verifiable();
            mockedStudentClassService.Setup(s => s.Save()).Throws<Exception>();

            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();
            mockedStudentClassFactory.Setup(f => f.CreateClass(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            var presenter = new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object);
            var ev = new AddNewClassEventArgs(null, null);

            // Act & Assert
            Assert.DoesNotThrow(() => mockedView.Raise(v => v.CreateClassClick += null, ev));
            Assert.AreEqual(expectedMessge, mockedView.Object.Model.ErrorMessage);
            Assert.IsFalse(mockedView.Object.Model.IsSuccess);

            // Verify that the method is stopped and other dependencies are not called
            mockedTeacherService.Verify(s => s.Save(), Times.Never);
            mockedTeacherService.Verify(s => s.FindById(It.IsAny<string>()), Times.Never);

            mockedStudentClassService.Verify(s => s.Add(It.IsAny<StudentClass>()), Times.Once);
        }

        [Test]
        public void SetErrorMessageInViewModel_IfNoChanges()
        {
            // Arrange
            var errorMessage = "Something is wrong!";
            var mockedView = new Mock<IAddNewClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddNewClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.Save()).Returns(0);
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.Add(It.IsAny<StudentClass>())).Verifiable();

            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();
            mockedStudentClassFactory.Setup(f => f.CreateClass(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            var presenter = new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object);
            var ev = new AddNewClassEventArgs(null, null);

            // Act & Assert
            Assert.DoesNotThrow(() => mockedView.Raise(v => v.CreateClassClick += null, ev));
            Assert.AreEqual(errorMessage, mockedView.Object.Model.ErrorMessage);
            Assert.IsFalse(mockedView.Object.Model.IsSuccess);

            // Verify that the method is stopped and other dependencies are not called
            mockedTeacherService.Verify(s => s.Save(), Times.Never);
            mockedTeacherService.Verify(s => s.FindById(It.IsAny<string>()), Times.Never);

            mockedStudentClassService.Verify(s => s.Add(It.IsAny<StudentClass>()), Times.Once);
        }

        [Test]
        public void SetViewModelIsSuccessProp_ToTrue_IfAllIsDone()
        {
            // Arrange
            var mockedView = new Mock<IAddNewClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddNewClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.Save()).Verifiable();
            mockedTeacherService.Setup(s => s.FindById(It.IsAny<string>())).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.Add(It.IsAny<StudentClass>())).Verifiable();
            mockedStudentClassService.Setup(s => s.Save()).Returns(1);

            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();
            mockedStudentClassFactory.Setup(f => f.CreateClass(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            var presenter = new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object);
            var ev = new AddNewClassEventArgs(null, null);

            // Act & Assert
            Assert.DoesNotThrow(() => mockedView.Raise(v => v.CreateClassClick += null, ev));
            Assert.IsNull(mockedView.Object.Model.ErrorMessage);
            Assert.IsTrue(mockedView.Object.Model.IsSuccess);

            // Verify that the method is stopped and other dependencies are not called
            mockedTeacherService.Verify(s => s.Save(), Times.Never);
            mockedTeacherService.Verify(s => s.FindById(It.IsAny<string>()), Times.Never);

            mockedStudentClassService.Verify(s => s.Add(It.IsAny<StudentClass>()), Times.Once);
        }
    }
}
