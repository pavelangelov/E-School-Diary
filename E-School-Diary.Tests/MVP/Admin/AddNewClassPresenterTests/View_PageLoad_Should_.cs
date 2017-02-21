using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.Admin.AddNewClassPresenterTests
{
    [TestFixture]
    public class View_PageLoad_Should_
    {
        [Test]
        public void CallTeacherService_GetTeachersWithoutClass_AndSetResultInViewModel()
        {
            // Arrange
            var teachers = new List<MinTeacherInfoDTO>() { new MinTeacherInfoDTO() { FirstName = "Test" } };
            var mockedView = new Mock<IAddNewClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddNewClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.GetTeachersWithoutClass()).Returns(teachers).Verifiable();

            var mockedStudentClassService = new Mock<IStudentClassService>();
            var mockedStudentClassFactory = new Mock<IStudentClassFactory>();

            var presenter = new AddNewClassPresenter(mockedView.Object, mockedStudentClassService.Object, mockedTeacherService.Object, mockedStudentClassFactory.Object);

            // Act
            mockedView.Raise(v => v.PageLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(teachers, mockedView.Object.Model.FreeTeachers);
            mockedTeacherService.Verify(s => s.GetTeachersWithoutClass(), Times.Once);
        }
    }
}
