using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Views.Admin.Register
{
    public interface IRegisterStudentView : IView<RegisterStudentViewModel>
    {
        event EventHandler<RegisterStudentPageLoadEventArgs> PageLoad;
        event EventHandler<RegisterStudentSubmitEventArgs> SubmitClick;
    }
}
