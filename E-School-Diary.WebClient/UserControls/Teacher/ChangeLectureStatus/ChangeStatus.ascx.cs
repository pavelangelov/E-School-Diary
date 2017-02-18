using System;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;
using E_School_Diary.WebClient.Presenters.Teacher;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.UserControls.Teacher.ChangeLectureStatus
{
    [PresenterBinding(typeof(ChangeLectureStatusPresenter))]
    public partial class ChangeStatus : MvpUserControl<ChangeLectureStatusViewModel>, IChangeLectureStatusView
    {
        public event EventHandler<UserIdEventArgs> PageLoad;
        public event EventHandler<ChangeLectureStatusEventArgs> UpdateStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadLectures();
            }
        }

        public void LoadLectures()
        {
            var id = Context.User.Identity.GetUserId();
            this.PageLoad?.Invoke(null, new UserIdEventArgs(id));

            this.LecturesGridView.DataSource = this.Model.Lectures;
            this.LecturesGridView.DataBind();
        }

        public void LecturesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)this.LecturesGridView.Rows[e.RowIndex];
            RadioButtonList buttons = (RadioButtonList)row.FindControl("StatusChange");

            var status = buttons.SelectedValue;
            var lectureId = buttons.Attributes["data-id"];
            if (status != null && status != "")
            {
                var ev = new ChangeLectureStatusEventArgs(lectureId, status);
                this.UpdateStatus?.Invoke(sender, ev);

                if (this.Model.IsSuccess)
                {
                    this.MessageContainer.ClearAll();
                    this.LecturesGridView_RowCancelingEdit(null, null);
                }
                else
                {
                    this.MessageContainer.ShowError(this.Model.ErrorMessage);
                }
            }
        }

        public void LecturesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.LecturesGridView.EditIndex = -1;
            this.LoadLectures();
        }

        public void LecturesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.LecturesGridView.EditIndex = e.NewEditIndex;
            this.LoadLectures();
        }
    }
}