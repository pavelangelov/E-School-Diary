using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Models.ViewModels.Student;

namespace E_School_Diary.WebClient.Views.Student
{
    public interface IStudentCalendarView : IView<StudentCalendarViewModel>
    {
        event EventHandler<CalendarEventArgs> LoadLectures;
    }
}
