using System;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.WebClient.UserControls.Admin
{
    [PresenterBinding(typeof(AddNewClassPresenter))]
    public partial class AddNewClass : MvpUserControl<AddNewClassViewModel>, IAddNewClassView
    {
        public event EventHandler PageLoad;
        public event EventHandler<AddNewClassEventArgs> CreateClassClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageLoad?.Invoke(sender, e);
                this.LoadTeachers();
            }
        }

        private void LoadTeachers()
        {
            this.Teachers.Items.Add(new ListItem("Select teacher"));
            foreach (var teacher in this.Model.FreeTeachers)
            {
                var text = $"Name: {teacher.FirstName} {teacher.LastName} Subject: {teacher.SubjectName}";
                var item = new ListItem(text, teacher.Id);
                this.Teachers.Items.Add(item);
            }
        }

        protected void CreateClass(object sender, EventArgs e)
        {
            // TODO: Validate class name for length and unique
            var className = this.ClassName.Text;
            var teacherId = this.Teachers.SelectedValue;

            if (className.Length < 2 || 15 < className.Length)
            {
                this.Error.Text = "Class name must be between 2 and 15 symbols.";
                this.errorContainer.Visible = true;
                this.successContainer.Visible = false;
            }

            this.CreateClassClick?.Invoke(sender, new AddNewClassEventArgs(className, teacherId));
            if (this.Model.IsSuccess)
            {
                this.Success.Text = "Class created successfully.";
                this.Teachers.Items.Remove(this.Teachers.SelectedItem);
                this.successContainer.Visible = true;
                this.errorContainer.Visible = false;
            }
            else
            {
                this.Error.Text = this.Model.ErrorMessage;
                this.errorContainer.Visible = true;
                this.successContainer.Visible = false;
            }
        }
    }
}