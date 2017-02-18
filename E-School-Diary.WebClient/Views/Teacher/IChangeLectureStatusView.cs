using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;

namespace E_School_Diary.WebClient.Views.Teacher
{
    public interface IChangeLectureStatusView : IView<ChangeLectureStatusViewModel>
    {
        event EventHandler<UserIdEventArgs> PageLoad;

        event EventHandler<ChangeLectureStatusEventArgs> UpdateStatus;
    }
}
