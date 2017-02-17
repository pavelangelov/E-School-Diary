using System;
using System.Collections.Generic;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Views.Teacher;
using E_School_Diary.Utils;

namespace E_School_Diary.WebClient.Presenters.Teacher
{
    public class AddMarksPresenter : Presenter<IAddMarksView>
    {
        private IStudentClassService studentClassService;
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IMarkFactory markFactory;
        private IMarkService markService;

        public AddMarksPresenter(
                        IAddMarksView view,
                        IStudentClassService studentClassService,
                        IStudentService studentService,
                        ITeacherService teacherService,
                        IMarkService markService,
                        IMarkFactory markFactory)
            : base(view)
        {
            Validator.ValidateForNull(studentClassService, "studentClassService");
            Validator.ValidateForNull(studentService, "studentService");
            Validator.ValidateForNull(teacherService, "teacherService");
            Validator.ValidateForNull(markService, "markService");
            Validator.ValidateForNull(markFactory, "markFactory");

            this.studentClassService = studentClassService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.markFactory = markFactory;
            this.markService = markService;

            this.View.PageLoad += View_PageLoad;
            this.View.ClassSelected += View_ClassSelected;
            this.View.InsertMarks += View_InsertMarks;
        }

        private void View_ClassSelected(object sender, SelectClassEventArgs e)
        {
            var students = this.studentService.FindByStudentClassId(e.ClassId).ToList();
            students.Sort();

            this.View.Model.Students = students;
        }

        private void View_PageLoad(object sender, UserIdEventArgs e)
        {
            var classes = this.teacherService.GetTeacherClasses(e.UserId).ToList();

            classes.Sort();
            this.View.Model.Classes = classes;
        }

        private void View_InsertMarks(object sender, AddMarksEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.TeacherId);
            var subject = teacher.Subject;

            try
            {
                var markToAdd = markFactory.GetMark(e.Mark.StudentId, subject, e.Mark.Value);
                this.markService.Add(markToAdd);
            }
            catch (ArgumentException ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.IsSuccess = false;
                return;
            }

            try
            {
                this.markService.Save();
            }
            catch (Exception)
            {
                this.View.Model.ErrorMessage = "Something`s wrong!";
                this.View.Model.IsSuccess = false;
                return;
            }

            this.View.Model.IsSuccess = true;
        }
    }
}