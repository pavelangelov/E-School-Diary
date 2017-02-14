using System;
using WebFormsMvp;

using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.WebClient.Presenters.Admin
{
    public class AddNewClassPresenter : Presenter<IAddNewClassView>
    {
        private IStudentClassService studentClassService;
        private ITeacherService teacherService;

        public AddNewClassPresenter(IAddNewClassView view, IStudentClassService stClassService, ITeacherService teacherService)
            : base(view)
        {
            this.studentClassService = stClassService;
            this.teacherService = teacherService;

            this.View.PageLoad += View_PageLoad;
            this.View.CreateClassClick += View_CreateClassClick;
        }

        private void View_PageLoad(object sender, EventArgs e)
        {
            var teachers = this.teacherService.GetTeachersWithoutClass();

            this.View.Model.FreeTeachers = teachers;
        }

        private void View_CreateClassClick(object sender, Models.CustomEventArgs.Admin.AddNewClassEventArgs e)
        {
            var stClass = new StudentClass()
            {
                Id = Guid.NewGuid().ToString(),
                Name = e.ClassName,
                FormMasterId = e.TeacherId
            };

            int changes = 0;
            try
            {
                this.studentClassService.Add(stClass);
                changes = this.studentClassService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something`s wrong. Maybe this class already exist.";
                return;
            }

            if (changes <= 0)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something is wrong!";
            }
            else
            {
                this.ChangeTeacherState(e.TeacherId);
                this.View.Model.IsSuccess = true;
            }
        }

        private void ChangeTeacherState(string teacherId)
        {
            if (teacherId != null)
            {
                var teacher = this.teacherService.FindById(teacherId);
                teacher.IsFreeTeacher = false;
                this.teacherService.Save();
            }
        }
    }
}