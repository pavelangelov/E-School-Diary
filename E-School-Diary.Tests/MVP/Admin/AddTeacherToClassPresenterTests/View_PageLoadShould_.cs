using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.Admin.AddTeacherToClassPresenterTests
{
    [TestFixture]
    public class View_PageLoadShould_
    {
        [Test]
        public void CallTeacherService_GetAllMethod_AndSetViewModelStudentsProp()
        {
            // Arrange
            var teachers = new List<User>() { new User() { Id = "id", FirstName = "firstName", LastName = "lastName", Subject = Subject.Biology } };
            var mockedView = new Mock<IAddTeacherToClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddTeacherToClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.GetAll()).Returns(teachers);

            var mockedStudentClassService = new Mock<IStudentClassService>();

            var presenter = new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, mockedStudentClassService.Object);

            // Act
            mockedView.Raise(v => v.PageLoad += null, EventArgs.Empty);
            var teacher = mockedView.Object.Model.Teachers.First();

            Assert.IsTrue(mockedView.Object.Model.Teachers.Count() == 1);
            Assert.AreEqual("id", teacher.Id);
            Assert.AreEqual("firstName", teacher.FirstName);
            Assert.AreEqual("lastName", teacher.LastName);
            Assert.AreEqual(Subject.Biology.ToString(), teacher.SubjectName);
        }
    }
}
