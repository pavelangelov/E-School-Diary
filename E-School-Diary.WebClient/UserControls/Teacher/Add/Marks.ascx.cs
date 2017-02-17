using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;
using E_School_Diary.WebClient.Presenters.Teacher;
using E_School_Diary.WebClient.Views.Teacher;
using E_School_Diary.Utils.DTOs.Add;

namespace E_School_Diary.WebClient.UserControls.Teacher.Add
{
    [PresenterBinding(typeof(AddMarksPresenter))]
    public partial class Marks : MvpUserControl<AddMarksViewModel>, IAddMarksView
    {
        public event EventHandler<UserIdEventArgs> PageLoad;
        public event EventHandler<SelectClassEventArgs> ClassSelected;
        public event EventHandler<AddMarksEventArgs> InsertMarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var teacherId = Context.User.Identity.GetUserId();
                var ev = new UserIdEventArgs(teacherId);
                this.PageLoad?.Invoke(sender, ev);

                this.LoadClasses();
            }
        }

        private void LoadClasses()
        {
            this.Classes.Items.Add("Select class");
            foreach (var cl in this.Model.Classes)
            {
                var item = new ListItem(cl.Name, cl.Id);
                this.Classes.Items.Add(item);
            }
        }

        protected void Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var teacherId = Context.User.Identity.GetUserId();
            var classId = this.Classes.SelectedValue;
            if (classId != null)
            {
                var ev = new SelectClassEventArgs(teacherId, classId);
                this.ClassSelected?.Invoke(sender, ev);

                this.LoadStudents();
            }
        }

        private void LoadStudents()
        {
            this.Students.DataSource = this.Model.Students;

            this.Students.DataBind();
        }

        protected void Students_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)this.Students.Rows[e.RowIndex];
            TextBox idContainer = (TextBox)row.Cells[0].Controls[0];
            TextBox markValue = (TextBox)row.Cells[4].Controls[0];
            double value;
            if (double.TryParse(markValue.Text, out value))
            {

                var markDTO = new AddMarkDTO() { StudentId = idContainer.Text, Value = value };
                var teacherId = Context.User.Identity.GetUserId();

                var ev = new AddMarksEventArgs(teacherId, markDTO);
                this.InsertMarks?.Invoke(sender, ev);

                if (this.Model.IsSuccess)
                {
                    this.Message.ShowSuccess("Mark added.");
                    this.Classes_SelectedIndexChanged(sender, e);
                }
                else
                {
                    this.Message.ShowError(this.Model.ErrorMessage);
                }
            }
        }

        protected void Students_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.Students.EditIndex = e.NewEditIndex;
            this.Classes_SelectedIndexChanged(sender, e);
        }

        protected void Students_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.Students.EditIndex = -1;
            this.Classes_SelectedIndexChanged(sender, e);
        }
    }
}