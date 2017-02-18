using System.Linq;

using WebFormsMvp;

using E_School_Diary.Utils;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Views.Student;
using E_School_Diary.WebClient.Models.CustomEventArgs;

namespace E_School_Diary.WebClient.Presenters.Student
{
    public class StudentMarksPresenter : Presenter<IStudentMarksView>
    {
        private IStudentService studentService;

        public StudentMarksPresenter(IStudentMarksView view, IStudentService studentService) 
            : base(view)
        {
            Validator.ValidateForNull(studentService, "studentService");

            this.studentService = studentService;

            this.View.PageLoad += View_PageLoad;
        }

        public void View_PageLoad(object sender, IdEventArgs e)
        {
            var marks = this.studentService.GetStudentMarks(e.Id).ToList();

            this.View.Model.Marks = marks;
        }
    }
}