using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Parent;

namespace E_School_Diary.WebClient.Views.Parent
{
    public interface IParentMessagesView : IView<ParentMessagesViewModel>
    {
        event EventHandler<IdEventArgs> PageLoad;
    }
}
