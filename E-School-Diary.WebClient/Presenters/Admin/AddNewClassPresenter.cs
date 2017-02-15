using System;

using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Views.Admin;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.Factories.Contracts;

namespace E_School_Diary.WebClient.Presenters.Admin
{
    public class AddNewClassPresenter : Presenter<IAddNewClassView>
    {
        private IStudentClassService studentClassService;
        private ITeacherService teacherService;
        private IStudentClassFactory studentClassFactory;

        public AddNewClassPresenter(IAddNewClassView view, IStudentClassService stClassService, ITeacherService teacherService, IStudentClassFactory studentClassFactory)
            : base(view)
        {
            if (stClassService == null)
            {
                throw new NullReferenceException("StudentClassService");
            }

            if (teacherService == null)
            {
                throw new NullReferenceException("TeacherService");
            }

            if (studentClassFactory == null)
            {
                throw new NullReferenceException("StudentClassFactory");
            }

            this.studentClassService = stClassService;
            this.teacherService = teacherService;
            this.studentClassFactory = studentClassFactory;

            this.View.PageLoad += View_PageLoad;
            this.View.CreateClassClick += View_CreateClassClick;
        }

        public void View_PageLoad(object sender, EventArgs e)
        {
            var teachers = this.teacherService.GetTeachersWithoutClass();

            this.View.Model.FreeTeachers = teachers;
        }

        public void View_CreateClassClick(object sender, AddNewClassEventArgs e)
        {
            // TODO: Check for validation error
            var stClass = this.studentClassFactory.CreateClass(e.ClassName, e.TeacherId);

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

        public void ChangeTeacherState(string teacherId)
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