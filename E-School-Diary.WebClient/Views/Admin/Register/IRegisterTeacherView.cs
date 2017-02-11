using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Register;

namespace E_School_Diary.WebClient.Views.Admin.Register
{
    public interface IRegisterTeacherView : IView<RegisterTeacherViewModel>
    {
        event EventHandler<RegisterTeacherEventArgs> RegisterTeacherClick;
    }
}