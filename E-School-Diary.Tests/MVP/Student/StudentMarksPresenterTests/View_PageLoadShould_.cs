using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Student;
using E_School_Diary.WebClient.Presenters.Student;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.Tests.MVP.Student.StudentMarksPresenterTests
{
    [TestFixture]
    public class View_PageLoadShould_
    {
        [Test]
        public void CallGetStudentMarksMethod_FromStudentService_AndSetMarksToViewModel()
        {
            // Arrange
            var mockedMarks = new List<MarkDTO>()
            {
                new MarkDTO() { Subject = "Math", Value = 4 },
                new MarkDTO() { Subject = "Sport", Value = 4 },
                new MarkDTO() { Subject = "Math", Value = 3 }
            }.GroupBy(m => m.Subject);

            var mockedView = new Mock<IStudentMarksView>();
            mockedView.Setup(v => v.Model).Returns(new StudentMarksViewModel());

            var mockedStudentService = new Mock<IStudentService>();
            mockedStudentService.Setup(s => s.GetStudentMarks(It.IsAny<string>())).Returns(mockedMarks);

            var ev = new IdEventArgs(null);
            var presenter = new StudentMarksPresenter(mockedView.Object, mockedStudentService.Object);

            // Act
            mockedView.Raise(v => v.PageLoad += null, ev);

            // Assert
            CollectionAssert.AreEqual(mockedMarks, mockedView.Object.Model.Marks);
        }
    }
}
