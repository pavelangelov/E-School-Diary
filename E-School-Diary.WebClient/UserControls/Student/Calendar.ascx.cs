using System;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Models.ViewModels.Student;
using E_School_Diary.WebClient.Presenters.Student;
using E_School_Diary.WebClient.Views.Student;

namespace E_School_Diary.WebClient.UserControls.Student
{
    [PresenterBinding(typeof(StudentCalendarPresenter))]
    public partial class Calendar : MvpUserControl<StudentCalendarViewModel>, IStudentCalendarView
    {
        public event EventHandler<CalendarEventArgs> LoadLectures;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoadLecturesClick(object sender, EventArgs e)
        {
            var userId = Context.User.Identity.GetUserId();
            var date = this.calendar.Value;
            if (date == null || date == string.Empty)
            {
                return;
            }

            if (this.Model.LastCheckedDate == date)
            {
                return;
            }

            // TODO: Replace this with hidden span in html, to check and prevent the event
            this.Model.LastCheckedDate = date;
            this.LoadLectures?.Invoke(sender, new CalendarEventArgs(date, userId));

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