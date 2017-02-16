using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Views.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

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
            if (studentClassService == null)
            {
                throw new ArgumentNullException("studentClassService");
            }

            if (studentService == null)
            {
                throw new ArgumentNullException("studentService");
            }

            if (teacherService == null)
            {
                throw new ArgumentNullException("teacherService");
            }

            if (markFactory == null)
            {
                throw new ArgumentNullException("markFactory");
            }

            if (markService == null)
            {
                throw new ArgumentNullException("markService");
            }

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

            this.View.Model.Students = students;
        }

        private void View_PageLoad(object sender, UserIdEventArgs e)
        {
            var classes = this.studentClassService.GetAll()
                                                    .Select(cl => new StudentClassDTO { Id = cl.Id, Name = cl.Name });
            classes.ToList().Sort();

            this.View.Model.Classes = classes;
        }

        private void View_InsertMarks(object sender, AddMarksEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.TeacherId);
            var subject = teacher.Subject;

            foreach (var mark in e.Marks)
            {
                try
                {
                    var markToAdd = markFactory.GetMark(mark.StudentId, subject, mark.Value);
                    this.markService.Add(markToAdd);
                }
                catch (ArgumentException ex)
                {
                    this.View.Model.ErrorMessage = ex.Message;
                    this.View.Model.IsSuccess = false;
                    return;
                }
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