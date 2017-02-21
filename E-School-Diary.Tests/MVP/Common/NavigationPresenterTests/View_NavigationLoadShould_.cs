using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

using E_School_Diary.Auth;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.Tests.MVP.Common.NavigationPresenterTests
{
    [TestFixture]
    class View_NavigationLoadShould_
    {
        [Test]
        public void FillViewModel_IfUserIsFind()
        {
            // Arrange
            var user = new ApplicationUser() { Email = "some@mail.com", FirstName = "Pesho", LastName = "Peshev", ImageUrl = "" };
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            userManager.Setup(m => m.FindByIdAsync(It.IsAny<string>())).Returns(Task.Run(() => { return user; }));

            var mockedView = new Mock<INavigationView>();
            mockedView.Setup(v => v.Model).Returns(new NavigationViewModel());

            var presenter = new NavigationPresenter(mockedView.Object);
            var ev = new NavigationEventArgs(null, userManager.Object);

            // Act
            mockedView.Raise(v => v.NavigationLoad += null, ev);

            // Assert
            Assert.AreEqual(user.Email, mockedView.Object.Model.Email);
            Assert.AreEqual(user.FirstName, mockedView.Object.Model.FirstName);
            Assert.AreEqual(user.LastName, mockedView.Object.Model.LastName);
            Assert.AreEqual(user.ImageUrl, mockedView.Object.Model.ImageUrl);
        }

        [Test]
        public void NotFillViewModel_IfUserIsFind()
        {
            // Arrange
            ApplicationUser user = null;
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            userManager.Setup(m => m.FindByIdAsync(It.IsAny<string>())).Returns(Task.Run(() => { return user; }));

            var mockedView = new Mock<INavigationView>();
            mockedView.Setup(v => v.Model).Returns(new NavigationViewModel());

            var presenter = new NavigationPresenter(mockedView.Object);
            var ev = new NavigationEventArgs(null, userManager.Object);

            // Act
            mockedView.Raise(v => v.NavigationLoad += null, ev);

            // Assert
            Assert.IsNull(mockedView.Object.Model.Email);
            Assert.IsNull(mockedView.Object.Model.FirstName);
            Assert.IsNull(mockedView.Object.Model.LastName);
            Assert.IsNull(mockedView.Object.Model.ImageUrl);
        }
    }
}
