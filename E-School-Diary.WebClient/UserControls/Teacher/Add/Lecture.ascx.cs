using System;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Utils.DTOs.Add;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;
using E_School_Diary.WebClient.Presenters.Teacher;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.UserControls.Teacher.Add
{
    [PresenterBinding(typeof(AddNewLecturePresenter))]
    public partial class Lecture : MvpUserControl<AddNewLectureViewModel>, IAddNewLectureView
    {
        public event EventHandler<UserIdEventArgs> PageLoad;
        public event EventHandler<AddNewLectureEventArgs> AddLectureClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title.InnerText = "Add new lecture";
                var userId = Context.User.Identity.GetUserId();
                this.PageLoad?.Invoke(sender, new UserIdEventArgs(userId));
                if (this.Model.ErrorMessage != null)
                {
                    this.Message.ShowError(this.Model.ErrorMessage);
                    this.AddBtn.Enabled = false;
                    return;
                }

                this.LoadLectureTimes();
                this.LoadClasses();
            }
        }

        protected void AddClick(object sender, EventArgs e)
        {
            var date = this.calendar.Value;
            if (date == null || date.Length == 0)
            {
                this.NoDate.Text = "No date selected!";
                return;
            }
            else
            {
                this.NoDate.Text = "";
            }

            var lectureDTO = new AddNewLectureDTO()
            {
                Title = this.LectureTitle.Text,
                TeacherId = Context.User.Identity.GetUserId(),
                StudentClassId = this.StudentClasses.SelectedValue,
                Date = this.calendar.Value,
                Start = this.StartTime.SelectedValue,
                End = this.EndTime.SelectedValue
            };

            this.AddLectureClick?.Invoke(sender, new AddNewLectureEventArgs(lectureDTO));

            if (this.Model.IsSuccess)
            {
                this.Message.ShowSuccess("Lecture added successfully.");
            }
            else
            {
                this.Message.ShowError(this.Model.ErrorMessage);
            }
        }

        public void LoadClasses()
        {
            foreach (var cl in this.Model.Classes)
            {
                var item = new ListItem(cl.Name, cl.Id);
                this.StudentClasses.Items.Add(item);
            }
        }

        public void LoadLectureTimes()
        {
            foreach (var hour in this.Model.LectureHours)
            {
                var startItem = new ListItem(hour.Item2, hour.Item1);
                var endItem = new ListItem(hour.Item2, hour.Item1);

                this.StartTime.Items.Add(startItem);
                this.EndTime.Items.Add(endItem);
            }
        }
    }
}