using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Models.Enums;
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
            this.LoadSubjects();
            this.CommonFields.RegistrationTitle = this.registrationTitle;
        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            var firstName = this.CommonFields.FirstName;
            var lastName = this.CommonFields.LastName;
            var email = this.CommonFields.Email;
            var age = this.CommonFields.Age;
            var password = this.CommonFields.Password;
            var subject = this.Subjects.SelectedValue;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            this.RegisterTeacherClick?.Invoke(sender, new RegisterTeacherEventArgs(
                firstName,
                lastName,
                email,
                password,
                age,
                subject,
                manager
                ));

            if (!this.Model.IsSuccess)
            {
                this.CommonFields.ErrorMessageContainer = this.Model.ErrorMessage;
            }
            else
            {
                this.CommonFields.SuccessMessageContainer = "Teacher registred successfully";
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