﻿using System;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;

namespace E_School_Diary.WebClient.Views.Teacher
{
    public interface ISendMessageView : IView<SendMessageViewModel>
    {
        event EventHandler<IdEventArgs> PageLoad;

        event EventHandler<IdEventArgs> ClassSelected;

        event EventHandler<SendMessageEventArgs> SendClick;
    }
}
