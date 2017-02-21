using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Parent;
using E_School_Diary.WebClient.Presenters.Parent;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.Tests.MVP.Parent.ChildLecturesPresenterTests
{
    public class View_PageLoadShould_
    {
        [Test]
        public void CallGetChildIdMethod_FromParentPresenter_AndSetIdInViewModel()
        {
            // Arrange
            var mockedView = new Mock<IChildLecturesView>();
            mockedView.Setup(v => v.Model).Returns(new ChildLecturesViewModel());

            var mockedParentService = new Mock<IParentService>();
            mockedParentService.Setup(s => s.GetChildId(It.IsAny<string>())).Returns("id").Verifiable();

            var mockedStudentService = new Mock<IStudentService>();
            var mockedDateParser = new Mock<IDateParser>();

            var ev = new IdEventArgs(null);
            var presenter = new ChildLecturesPresenter(mockedView.Object, mockedParentService.Object, mockedStudentService.Object, mockedDateParser.Object);

            // Act
            mockedView.Raise(v => v.PageLoad += null, ev);

            // Assert
            Assert.AreEqual("id", mockedView.Object.Model.ChildId);
            mockedParentService.Verify(s => s.GetChildId(It.IsAny<string>()), Times.Once);
        }
    }
}
