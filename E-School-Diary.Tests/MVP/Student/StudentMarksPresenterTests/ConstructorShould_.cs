using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Presenters.Student;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.Tests.MVP.Student.StudentMarksPresenterTests
{
    [TestFixture]
    public class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfStudentServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IStudentMarksView>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new StudentMarksPresenter(mockedView.Object, null)).Message;
            Assert.IsTrue(message.Contains("studentService"));
        }

        [Test]
        public void NotToThrow_IfStudentServiceIsValid()
        {
            // Arrange
            var mockedView = new Mock<IStudentMarksView>();
            var mockedStudentService = new Mock<IStudentService>();

            // Act & Assert
            Assert.DoesNotThrow(() => new StudentMarksPresenter(mockedView.Object, mockedStudentService.Object));
        }
    }
}
