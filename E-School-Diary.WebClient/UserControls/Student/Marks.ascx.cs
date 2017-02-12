﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Models.ViewModels.Student;
using E_School_Diary.WebClient.Presenters.Student;
using E_School_Diary.WebClient.Views.Student;
using E_School_Diary.Models.Enums;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.UserControls.Student
{
    [PresenterBinding(typeof(StudentMarksPresenter))]
    public partial class Marks : MvpUserControl<StudentMarksViewModel>, IStudentMarksView
    {
        public event EventHandler<UserIdEventArgs> PageLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Context.User.Identity.GetUserId();
            this.PageLoad?.Invoke(sender, new UserIdEventArgs(userId));

            this.MarksList.DataSource = this.Model.Marks;
            this.MarksList.DataBind();
        }
    }
}