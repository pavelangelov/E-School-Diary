using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;

namespace E_School_Diary.WebClient.Views.Admin
{
    public interface IAddNewClassView : IView<AddNewClassViewModel>
    {
        event EventHandler<AddNewClassEventArgs> CreateClassClick;
    }
}
