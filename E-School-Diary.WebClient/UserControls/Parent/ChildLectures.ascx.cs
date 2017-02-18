using System;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Models.ViewModels.Parent;
using E_School_Diary.WebClient.Presenters.Parent;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.WebClient.UserControls.Parent
{
    [PresenterBinding(typeof(ChildLecturesPresenter))]
    public partial class ChildLectures : MvpUserControl<ChildLecturesViewModel>, IChildLecturesView
    {
        public event EventHandler<IdEventArgs> PageLoad;
        public event EventHandler<CalendarEventArgs> LoadLectures;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Context.User.Identity.GetUserId();
            var ev = new IdEventArgs(id);
            this.PageLoad?.Invoke(sender, ev);
        }

        protected void LoadLecturesClick(object sender, EventArgs e)
        {
            var date = this.calendar.Value;
            if (date == null || date == string.Empty)
            {
                return;
            }

            this.LoadLectures?.Invoke(sender, new CalendarEventArgs(date, this.Model.ChildId));

            this.AttachLectures(date);
        }

        public void AttachLectures(string date)
        {
            this.ActiveTitle.InnerText = $"Active lectures for {date}";
            this.ActiveLectures.DataSource = this.Model.AheadLectures;

            this.CanceledTitle.InnerText = $"Canceled lectures for {date}";
            this.CanceledLectures.DataSource = this.Model.CanceledLectures;

            this.PastTitle.InnerText = $"Past lectures for {date}";
            this.PastLectures.DataSource = this.Model.PastLectures;

            this.ActiveLectures.DataBind();
            this.CanceledLectures.DataBind();
            this.PastLectures.DataBind();
        }
    }
}