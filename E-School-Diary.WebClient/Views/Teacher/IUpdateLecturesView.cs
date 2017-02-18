using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels;

namespace E_School_Diary.WebClient.Views.Teacher
{
    public interface IUpdateLecturesView : IView<BaseViewModel>
    {
        event EventHandler<IdEventArgs> UpdateClick;
    }
}