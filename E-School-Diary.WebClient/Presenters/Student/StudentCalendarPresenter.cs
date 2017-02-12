using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.WebClient.Presenters.Student
{
    public class StudentCalendarPresenter : Presenter<IStudentCalendarView>
    {
        public StudentCalendarPresenter(IStudentCalendarView view) 
            : base(view)
        {
            this.View.LoadLectures += View_LoadLectures;
        }

        private void View_LoadLectures(object sender, CalendarEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}