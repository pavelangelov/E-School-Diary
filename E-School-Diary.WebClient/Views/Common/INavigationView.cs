using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Common;

namespace E_School_Diary.WebClient.Views.Common
{
    public interface INavigationView : IView<NavigationViewModel>
    {
        event EventHandler<NavigationEventArgs> NavigationLoad;
    }
}
