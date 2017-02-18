using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels;
using E_School_Diary.WebClient.Presenters.Teacher;
using E_School_Diary.WebClient.Views.Teacher;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace E_School_Diary.WebClient.UserControls.Teacher.UpdateLectures
{
    [PresenterBinding(typeof(UpdateLecturesPresenter))]
    public partial class UpdateLectures : MvpUserControl<BaseViewModel>, IUpdateLecturesView
    {
        private string pageTitle = "Update lectures";

        public event EventHandler<IdEventArgs> UpdateClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.title.InnerText = this.pageTitle;
        }

        protected void Update_Lectures(object sender, EventArgs e)
        {
            var teacherId = Context.User.Identity.GetUserId();
            var ev = new IdEventArgs(teacherId);
            this.UpdateClick?.Invoke(sender, ev);

            if (this.Model.IsSuccess)
            {
                this.Message.ShowSuccess("Your lectures are updated.");
            }
            else
            {
                this.Message.ShowError(this.Model.ErrorMessage);
            }
        }
    }
}