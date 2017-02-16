using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Views.Teacher
{
    public interface IAddNewLectureView : IView<AddNewLectureViewModel>
    {
        event EventHandler<UserIdEventArgs> PageLoad;
        event EventHandler<AddNewLectureEventArgs> AddLectureClick;
    }
}
