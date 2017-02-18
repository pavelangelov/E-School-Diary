using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Models.ViewModels.Parent;

namespace E_School_Diary.WebClient.Views.Parent
{
    public interface IChildLecturesView : IView<ChildLecturesViewModel>
    {
        event EventHandler<IdEventArgs> PageLoad;
        event EventHandler<CalendarEventArgs> LoadLectures;
    }
}
