using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Auth;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Models.ViewModels.Register;
using E_School_Diary.WebClient.Presenters.Register;
using E_School_Diary.WebClient.Views.Register;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.WebClient.UserControls.Registration
{
    [PresenterBinding(typeof(RegisterParentPresenter))]
    public partial class RegisterParent : MvpUserControl<RegisterParentViewModel>, IRegisterParentView
    {
        public event EventHandler PageLoad;
        public event EventHandler<IdEventArgs> StudentClassSelected;
        public event EventHandler<RegisterParentClickEventArgs> RegisterParentClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageLoad?.Invoke(sender, e);

                this.LoadClasses();
            }
        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            var studentId = this.Students.SelectedValue;
            if (studentId == null || studentId == "")
            {
                this.StudentSelectError.Text = "Student select is required.";
                this.StudentSelectError.Visible = true;
                return;
            }

            var parentDTO = new RegisterParentDTO()
            {
                Email = this.CommonFields.Email,
                Password = this.CommonFields.Password,
                FirstName = this.CommonFields.FirstName,
                LastName = this.CommonFields.LastName,
                Age = this.CommonFields.Age,
                ChildId = studentId
            };
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var ev = new RegisterParentClickEventArgs(parentDTO, manager);
            this.RegisterParentClick?.Invoke(sender, ev);

            if (this.Model.IsSuccess)
            {
                this.CommonFields.ShowSuccess("Parent registred");
            }
            else
            {
                this.CommonFields.ShowError(this.Model.ErrorMessage);
            }
        }

        protected void Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classId = this.Classes.SelectedValue;
            if (classId == null || classId == "")
            {
                return;
            }

            var ev = new IdEventArgs(classId);
            this.StudentClassSelected?.Invoke(sender, ev);

            this.LoadStudents();
        }

        private void LoadStudents()
        {
            this.Students.Items.Clear();
            foreach (var student in this.Model.Students)
            {
                var text = $"{student.FirstName} {student.MiddleName ?? ""} {student.LastName}";
                var item = new ListItem(text, student.Id);
                this.Students.Items.Add(item);
            }
        }

        private void LoadClasses()
        {
            this.Classes.Items.Clear();

            this.Classes.Items.Add("No item selected");
            foreach (var cl in this.Model.Classes)
            {
                var item = new ListItem(cl.Name, cl.Id);
                this.Classes.Items.Add(item);
            }
        }
    }
}