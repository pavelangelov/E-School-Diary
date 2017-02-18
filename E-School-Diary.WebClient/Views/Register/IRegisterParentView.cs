using System;
using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Models.ViewModels.Register;

namespace E_School_Diary.WebClient.Views.Register
{
    public interface IRegisterParentView : IView<RegisterParentViewModel>
    {
        event EventHandler PageLoad;

        event EventHandler<IdEventArgs> StudentClassSelected;

        event EventHandler<RegisterParentClickEventArgs> RegisterParentClick;
    }
}
