using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Views.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Presenters.Student
{
    public class StudentMarksPresenter : Presenter<IStudentMarksView>
    {
        private IStudentRepository studentRepository;

        public StudentMarksPresenter(IStudentMarksView view, IStudentRepository studentRepository) 
            : base(view)
        {
            this.studentRepository = studentRepository;

            this.View.PageLoad += View_PageLoad;
        }

        private void View_PageLoad(object sender, UserIdEventArgs e)
        {
            var marks = this.studentRepository.GetStudentMarks(e.UserId).ToList();

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