using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Views.Admin
{
    public interface IAddTeacherToClassView : IView<AddTeacherToClassViewModel>
    {
        event EventHandler PageLoad;
        event EventHandler<UserIdEventArgs> TeacherSelected;
        event EventHandler<AddTeacherToClassEventArgs> AddTeacherClick;
    }
}
