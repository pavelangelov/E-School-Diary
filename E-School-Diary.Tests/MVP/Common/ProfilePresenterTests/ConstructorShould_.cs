using System;

using Moq;
using NUnit.Framework;

using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.Tests.MVP.Common.ProfilePresenterTests
{
    class ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfUserServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IProfileView>();
            var mockedImageService = new Mock<IImageUploadService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new ProfilePresenter(mockedView.Object, null, mockedImageService.Object)).Message;
            Assert.IsTrue(message.Contains("userService"));
        }

        [Test]
        public void ThrowArgumentNullException_IfImageUploadServiceIsNull()
        {
            // Arrange
            var mockedView = new Mock<IProfileView>();
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new ProfilePresenter(mockedView.Object, mockedUserService.Object, null)).Message;
            Assert.IsTrue(message.Contains("imageUploadService"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            // Arrange
            var mockedView = new Mock<IProfileView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedImageService = new Mock<IImageUploadService>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ProfilePresenter(mockedView.Object, mockedUserService.Object, mockedImageService.Object));
        }
    }
}
