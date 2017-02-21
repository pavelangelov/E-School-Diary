using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.WebClient.Presenters.Parent;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.Tests.MVP.Parent.ChildLecturesPresenterTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfParentServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IChildLecturesView>();
            var mockedStudentService = new Mock<IStudentService>();
            var mockedDateParser = new Mock<IDateParser>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new ChildLecturesPresenter(mockedView.Object, null, mockedStudentService.Object, mockedDateParser.Object)).Message;
            Assert.IsTrue(message.Contains("parentService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfStudentServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IChildLecturesView>();
            var mockedParentService = new Mock<IParentService>();
            var mockedDateParser = new Mock<IDateParser>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new ChildLecturesPresenter(mockedView.Object, mockedParentService.Object, null, mockedDateParser.Object)).Message;
            Assert.IsTrue(message.Contains("studentService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfDateParserIsNull()
        {
            // Arrange
            var mockedView = new Mock<IChildLecturesView>();
            var mockedParentService = new Mock<IParentService>();
            var mockedStudentService = new Mock<IStudentService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new ChildLecturesPresenter(mockedView.Object, mockedParentService.Object, mockedStudentService.Object, null)).Message;
            Assert.IsTrue(message.Contains("dateParser"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            // Arrange
            var mockedView = new Mock<IChildLecturesView>();
            var mockedParentService = new Mock<IParentService>();
            var mockedStudentService = new Mock<IStudentService>();
            var mockedDateParser = new Mock<IDateParser>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ChildLecturesPresenter(mockedView.Object,mockedParentService.Object, mockedStudentService.Object, mockedDateParser.Object));
        }
    }
}
