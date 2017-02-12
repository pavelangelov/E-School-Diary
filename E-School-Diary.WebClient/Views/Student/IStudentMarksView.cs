using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Models.ViewModels.Student;

namespace E_School_Diary.WebClient.Views.Student
{
    public interface IStudentMarksView : IView<StudentMarksViewModel>
    {
        event EventHandler<UserIdEventArgs> PageLoad;
    }
}