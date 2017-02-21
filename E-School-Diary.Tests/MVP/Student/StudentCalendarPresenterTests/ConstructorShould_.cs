using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.WebClient.Presenters.Student;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.Tests.MVP.Student.StudentCalendarPresenterTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfStudentServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IStudentCalendarView>();
            var mockedDateParser = new Mock<IDateParser>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new StudentCalendarPresenter(mockedView.Object, null, mockedDateParser.Object)).Message;
            Assert.IsTrue(message.Contains("studentService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfDateParserIsNull()
        {
            // Arrange
            var mockedView = new Mock<IStudentCalendarView>();
            var mockedStudentService = new Mock<IStudentService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new StudentCalendarPresenter(mockedView.Object, mockedStudentService.Object, null)).Message;
            Assert.IsTrue(message.Contains("dateParser"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            // Arrange
            var mockedView = new Mock<IStudentCalendarView>();
            var mockedStudentService = new Mock<IStudentService>();
            var mockedDateParser = new Mock<IDateParser>();

            // Act & Assert
            Assert.DoesNotThrow(() => new StudentCalendarPresenter(mockedView.Object, mockedStudentService.Object, mockedDateParser.Object));
        }
    }
}
