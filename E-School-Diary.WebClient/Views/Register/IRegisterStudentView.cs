using System;
using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Models.ViewModels.Register;

namespace E_School_Diary.WebClient.Views.Register
{
    public interface IRegisterStudentView : IView<RegisterStudentViewModel>
    {
        event EventHandler<RegisterStudentPageLoadEventArgs> PageLoad;
        event EventHandler<RegisterStudentSubmitEventArgs> SubmitClick;
    }
}
