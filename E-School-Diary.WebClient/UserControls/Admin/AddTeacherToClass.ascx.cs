using System;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.WebClient.UserControls.Admin
{
    [PresenterBinding(typeof(AddTeacherToClassPresenter))]
    public partial class AddTeacherToClass : MvpUserControl<AddTeacherToClassViewModel>, IAddTeacherToClassView
    {
        public event EventHandler PageLoad;
        public event EventHandler<IdEventArgs> TeacherSelected;
        public event EventHandler<AddTeacherToClassEventArgs> AddTeacherClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageLoad?.Invoke(sender, e);
                this.LoadTeachers();
            }
        }

        protected void Teachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var teacherId = this.Teachers.SelectedValue;
            if (teacherId != null && teacherId != "")
            {
                this.TeacherSelected?.Invoke(sender, new IdEventArgs(teacherId));
                this.LoadClasses();
            }
        }

        public void LoadClasses()
        {
            this.Classes.Items.Clear();
            foreach (var cl in this.Model.AvailableClasses)
            {
                var item = new ListItem(cl.Name, cl.Id);
                this.Classes.Items.Add(item);
            }
        }

        public void LoadTeachers()
        {
            this.Teachers.Items.Clear();
            this.Teachers.Items.Add("Choose teacher");
            foreach (var teacher in this.Model.Teachers)
            {
                var text = $"{teacher.FirstName} {teacher.LastName} Subject: {teacher.SubjectName}";
                var item = new ListItem(text, teacher.Id);
                this.Teachers.Items.Add(item);
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Session["isDone"]!=null)
            {
                this.ClearLists();
                return;
            }

            var teacherId = this.Teachers.SelectedValue;
            var classId = this.Classes.SelectedValue;
            var ev = new AddTeacherToClassEventArgs(teacherId, classId);

            this.AddTeacherClick?.Invoke(sender, ev);

            if (this.Model.IsSuccess)
            {
                Session["isDone"] = true;
                this.Message.ShowSuccess("This teacher now can teaching in this class. To add new class please reload the page.");

                this.ClearLists();
            }
            else
            {
                this.Message.ShowError(this.Model.ErrorMessage);
            }
        }

        private void ClearLists()
        {

            this.Teachers.Items.Clear();
            this.Classes.Items.Clear();
            this.AddBtn.Enabled = false;
        }
    }
}