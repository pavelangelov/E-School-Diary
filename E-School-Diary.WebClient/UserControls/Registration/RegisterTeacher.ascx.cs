﻿using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Auth;
using E_School_Diary.Data.Enums;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using E_School_Diary.WebClient.Presenters.Register;
using E_School_Diary.WebClient.Views.Register;

namespace E_School_Diary.WebClient.UserControls.Registration
{
    [PresenterBinding(typeof(RegisterTeacherPresenter))]
    public partial class RegisterTeacher : MvpUserControl<RegisterTeacherViewModel>, IRegisterTeacherView
    {
        public event EventHandler<RegisterTeacherEventArgs> RegisterTeacherClick;

        private string registrationTitle = "New Teacher Registration";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadSubjects();
                this.CommonFields.RegistrationTitle = this.registrationTitle;
            }
        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            var teacherDTO = new RegisterTeacherDTO()
            {
                FirstName = this.CommonFields.FirstName,
                LastName = this.CommonFields.LastName,
                Email = this.CommonFields.Email,
                Age = this.CommonFields.Age,
                Password = this.CommonFields.Password,
                Subject = this.Subjects.SelectedValue
            };

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            this.RegisterTeacherClick?.Invoke(sender, new RegisterTeacherEventArgs(teacherDTO, manager));

            if (!this.Model.IsSuccess)
            {
                this.CommonFields.ShowError(this.Model.ErrorMessage);
            }
            else
            {
                this.CommonFields.ShowSuccess("Teacher registred successfully");
            }
        }

        private void LoadSubjects()
        {
            foreach (var r in Enum.GetValues(typeof(Subject)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(Subject), r), r.ToString());
                this.Subjects.Items.Add(item);
            }

            this.Subjects.DataBind();
        }
    }
}