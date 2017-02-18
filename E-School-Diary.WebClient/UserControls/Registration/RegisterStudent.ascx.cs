using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Auth;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using E_School_Diary.WebClient.Presenters.Register;
using E_School_Diary.WebClient.Views.Register;

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
                    this.CommonFields.ShowError(this.Model.ErrorMessage);
                    this.BtnSubmit.Enabled = false;
                    return;
                }

                this.FormMaster.Text = this.Model.TeacherInfo.TeacherNames;
            }
        }

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
                this.CommonFields.ShowError(this.Model.ErrorMessage);
            }
            else
            {
                this.CommonFields.ShowSuccess("Student registred successfully");
            }
        }
    }
}