using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.Tests.MVP.Admin.AddTeacherToClassPresenterTests
{
    [TestFixture]
    public class View_TeacherSelectedShould_
    {
        [Test]
        public void GetAllClassesFromDB_AndRemoveTeacherClassesFromThem_BeforeSetToViewModel()
        {
            // Arrange
            var classes = new List<StudentClass>()
            { new StudentClass("1A"), new StudentClass("1B"), new StudentClass("1C")};
            var teacherClassId = classes[1].Id;
            var teacherClasses = new List<StudentClassDTO>() { new StudentClassDTO { Id = teacherClassId, Name = "1B" } };

            var mockedView = new Mock<IAddTeacherToClassView>();
            mockedView.Setup(v => v.Model).Returns(new AddTeacherToClassViewModel());

            var mockedTeacherService = new Mock<ITeacherService>();
            mockedTeacherService.Setup(s => s.GetTeacherClasses(It.IsAny<string>())).Returns(teacherClasses);

            var mockedStudentClassService = new Mock<IStudentClassService>();
            mockedStudentClassService.Setup(s => s.GetAll()).Returns(classes);

            var presenter = new AddTeacherToClassPresenter(mockedView.Object, mockedTeacherService.Object, mockedStudentClassService.Object);

            // Act
            var ev = new IdEventArgs(null);
            mockedView.Raise(v => v.TeacherSelected += null, ev);

            // Assert
            Assert.IsTrue(mockedView.Object.Model.AvailableClasses.Count() == 2);
            Assert.IsFalse(mockedView.Object.Model.AvailableClasses.Any(c => c.Id == teacherClassId));
            
        }
    }
}
