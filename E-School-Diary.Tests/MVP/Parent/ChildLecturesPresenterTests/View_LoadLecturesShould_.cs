using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Models.ViewModels.Parent;
using E_School_Diary.WebClient.Presenters.Parent;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.Tests.MVP.Parent.ChildLecturesPresenterTests
{
    [TestFixture]
    public class View_LoadLecturesShould_
    {
        [Test]
        public void FillViewModel_WithCorectLecturesForEveryCollection()
        {
            // Arrange
            var lectures = new List<LectureDTO>()
            {
                new LectureDTO {Start = DateTime.Now, End = DateTime.Now.AddHours(1), Status = "Past"},
                new LectureDTO {Start = DateTime.Now, End = DateTime.Now.AddHours(1), Status = "Ahead"},
                new LectureDTO {Start = DateTime.Now, End = DateTime.Now.AddHours(1), Status = "Canceled"}
            };

            var mockedView = new Mock<IChildLecturesView>();
            mockedView.Setup(v => v.Model).Returns(new ChildLecturesViewModel());

            var mockedParentService = new Mock<IParentService>();

            var mockedStudentService = new Mock<IStudentService>();
            mockedStudentService.Setup(s => s.GetStudentLectures(It.IsAny<string>())).Returns(lectures);

            var mockedDateParser = new Mock<IDateParser>();
            mockedDateParser.Setup(d => d.ExtractDate(It.IsAny<string>())).Returns(DateTime.Now);

            var ev = new CalendarEventArgs(null, null);
            var presenter = new ChildLecturesPresenter(mockedView.Object, mockedParentService.Object, mockedStudentService.Object, mockedDateParser.Object);

            // Act
            mockedView.Raise(v => v.LoadLectures += null, ev);

            // Assert
            Assert.IsTrue(mockedView.Object.Model.AheadLectures.Count() == 1);
            Assert.IsTrue(mockedView.Object.Model.PastLectures.Count() == 1);
            Assert.IsTrue(mockedView.Object.Model.CanceledLectures.Count() == 1);
        }
    }
}
