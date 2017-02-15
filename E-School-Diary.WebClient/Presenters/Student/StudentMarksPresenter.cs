using System;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.WebClient.Presenters.Student
{
    public class StudentMarksPresenter : Presenter<IStudentMarksView>
    {
        private IStudentService studentService;

        public StudentMarksPresenter(IStudentMarksView view, IStudentService studentService) 
            : base(view)
        {
            if (studentService == null)
            {
                throw new NullReferenceException("StudentService");
            }

            this.studentService = studentService;

            this.View.PageLoad += View_PageLoad;
        }

        public void View_PageLoad(object sender, UserIdEventArgs e)
        {
            var marks = this.studentService.GetStudentMarks(e.UserId).ToList();

            //var result = new List<Tuple<string, string>>();

            //foreach (var mark in marks)
            //{
            //    var marksValues = "";
            //    foreach (var k in mark)
            //    {
            //        marksValues += k.Value;
            //    }

            //    result.Add(new Tuple<string, string>(mark.Key.ToString(), marksValues));
            //}

            this.View.Model.Marks = marks;
        }
    }
}