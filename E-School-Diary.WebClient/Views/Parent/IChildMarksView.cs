using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Student;

namespace E_School_Diary.WebClient.Views.Parent
{
    public interface IChildMarksView : IView<StudentMarksViewModel>
    {
        event EventHandler<IdEventArgs> PageLoad;
    }
}