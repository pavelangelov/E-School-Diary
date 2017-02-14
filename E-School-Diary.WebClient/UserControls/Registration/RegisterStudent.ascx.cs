﻿using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using E_School_Diary.WebClient.Presenters.Admin.Register;
using E_School_Diary.WebClient.Views.Admin.Register;

namespace E_School_Diary.WebClient.UserControls.Registration
{
    [PresenterBinding(typeof(RegisterStudentPresenter))]
    public partial class RegisterStudent : MvpUserControl<RegisterStudentViewModel>, IRegisterStudentView
    {
        private string registrationTitle = "New Student Registration";

        public event EventHandler<RegisterStudentPageLoadEventArgs> PageLoad;
        public event EventHandler<RegisterStudentSubmitEventArgs> SubmitClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CommonFields.RegistrationTitle = this.registrationTitle;
                var userId = Context.User.Identity.GetUserId();
                this.PageLoad?.Invoke(sender, new RegisterStudentPageLoadEventArgs(userId));

                if (this.Model.ErrorMessage != null)
                {
                    this.CommonFields.ErrorMessageContainer = this.Model.ErrorMessage;
                    this.CommonFields.ShowErrorContainer();
                    this.BtnSubmit.Enabled = false;
                    return;
                }

                this.FormMaster.Text = this.Model.TeacherInfo.TeacherNames;
                this.StudentClass.Text = "Your class.";
            }
        }

        //private void LoadTeachers()
        //{
        //    foreach (var teacher in this.Model.Teachers)
        //    {
        //        var item = new ListItem(teacher.Item1, teacher.Item2);
        //        this.FormMaster.Items.Add(item);
        //    }
        //}

        //private void LoadClasses()
        //{
        //    foreach (var stClass in this.Model.Classes)
        //    {
        //        var item = new ListItem(stClass.Item1, stClass.Item2);
        //        this.StudentClasses.Items.Add(item);
        //    }
        //}

        protected void RegisterClick(object sender, EventArgs e)
        {
            var studentDTO = new RegisterStudentDTO()
            {
                FirstName = this.CommonFields.FirstName,
                LastName = this.CommonFields.LastName,
                Email = this.CommonFields.Email,
                Age = this.CommonFields.Age,
                Password = this.CommonFields.Password,
                FormMasterId = Context.User.Identity.GetUserId()
            };

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            this.SubmitClick?.Invoke(sender, new RegisterStudentSubmitEventArgs(studentDTO, manager));

            if (!this.Model.IsSuccess)
            {
                this.CommonFields.ErrorMessageContainer = this.Model.ErrorMessage;
                this.CommonFields.ShowErrorContainer();
                this.CommonFields.SuccessMessageContainer = "";
            }
            else
            {
                this.CommonFields.SuccessMessageContainer = "Student registred successfully";
                this.CommonFields.ErrorMessageContainer = "";
                this.CommonFields.ShowSuccessContainer();
            }
        }
    }
}