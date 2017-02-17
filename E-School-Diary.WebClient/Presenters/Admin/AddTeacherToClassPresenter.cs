using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Presenters.Admin
{
    public class AddTeacherToClassPresenter : Presenter<IAddTeacherToClassView>
    {
        private ITeacherService teacherService;
        private IStudentClassService studentClassService;

        public AddTeacherToClassPresenter(IAddTeacherToClassView view, ITeacherService teacherService, IStudentClassService studentClassService) 
            : base(view)
        {
            Validator.ValidateForNull(teacherService, "teacherService");
            Validator.ValidateForNull(studentClassService, "studentClassService");

            this.teacherService = teacherService;
            this.studentClassService = studentClassService;

            this.View.PageLoad += View_PageLoad;
            this.View.TeacherSelected += View_TeacherSelected;
            this.View.AddTeacherClick += View_AddTeacherClick;
        }

        public void View_AddTeacherClick(object sender, AddTeacherToClassEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.TeacherId);
            var selectedClass = this.studentClassService.FindById(e.ClassId);

            teacher.StudentClasses.Add(selectedClass);

            try
            {
                this.teacherService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something`s wrong.";
                return;
            }

            this.View.Model.IsSuccess = true;
        }

        public void View_TeacherSelected(object sender, UserIdEventArgs e)
        {
            var classes = this.studentClassService.GetAll();
            var teacherClasses = this.teacherService.GetTeacherClasses(e.UserId);
            var availableClasses = new List<StudentClassDTO>();

            foreach (var cl in classes)
            {
                if (!teacherClasses.Any(c => c.Id == cl.Id))
                {
                    availableClasses.Add(new StudentClassDTO { Id = cl.Id, Name = cl.Name });
                }
            }

            availableClasses.Sort();

            this.View.Model.AvailableClasses = availableClasses;
        }

        public void View_PageLoad(object sender, EventArgs e)
        {
            var teachers = this.teacherService.GetAll();

            this.View.Model.Teachers = teachers.Select(t => new MinTeacherInfoDTO
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                SubjectName = t.Subject.ToString()
            });
        }
    }
}