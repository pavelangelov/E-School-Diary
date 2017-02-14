using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Data.Enums;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using E_School_Diary.WebClient.Presenters.Admin.Register;
using E_School_Diary.WebClient.Views.Admin.Register;

namespace E_School_Diary.WebClient.UserControls.Registration
{
    [PresenterBinding(typeof(RegisterTeacherPresenter))]
    public partial class RegisterTeacher : MvpUserControl<RegisterTeacherViewModel>, IRegisterTeacherView
    {
        public event EventHandler<RegisterTeacherEventArgs> RegisterTeacherClick;

        private string registrationTitle = "New Teacher Registration";
        //private ApplicationUserManager manager;

        public RegisterTeacher()
        {
            //this.manager = 
        }

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
                this.CommonFields.ErrorMessageContainer = this.Model.ErrorMessage;
                this.CommonFields.SuccessMessageContainer = "";
            }
            else
            {
                this.CommonFields.SuccessMessageContainer = "Teacher registred successfully";
                this.CommonFields.ErrorMessageContainer = "";
            }

            this.CommonFields.ShowResultContainer();
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