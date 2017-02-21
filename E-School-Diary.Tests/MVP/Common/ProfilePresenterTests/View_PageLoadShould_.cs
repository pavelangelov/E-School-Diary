using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.Tests.MVP.Common.ProfilePresenterTests
{
    [TestFixture]
    public class View_PageLoadShould_
    {
        [Test]
        public void CallUserService_GetMinInfoMethod_AndFillViewModel_WhenPageIsLoad()
        {
            // Arrange
            var mockedUserInfo = new UserDTO() { FirstName = "Pesho", LastName = "Peshev", Username = "pesho", ImageUrl = "image" };
            var mockedImageService = new Mock<IImageUploadService>();
            var mockedView = new Mock<IProfileView>();
            mockedView.Setup(v => v.Model).Returns(new ProfileViewModel());

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetMinInfo(It.IsAny<string>())).Returns(mockedUserInfo);

            var presenter = new ProfilePresenter(mockedView.Object, mockedUserService.Object, mockedImageService.Object);
            var ev = new IdEventArgs(null);

            // Act
            mockedView.Raise(v => v.PageLoad += null, ev);

            // Assert
            Assert.AreEqual($"{mockedUserInfo.FirstName}  {mockedUserInfo.LastName}", mockedView.Object.Model.Names);
            Assert.AreEqual(mockedUserInfo.Username, mockedView.Object.Model.Username);
            Assert.AreEqual(mockedUserInfo.ImageUrl, mockedView.Object.Model.ImageUrl);
        }
    }
}
