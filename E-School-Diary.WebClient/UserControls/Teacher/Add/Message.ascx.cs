using System;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Models.ViewModels.Teacher;
using E_School_Diary.WebClient.Presenters.Teacher;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.UserControls.Teacher.Add
{
    [PresenterBinding(typeof(SendMessagePresenter))]
    public partial class Message : MvpUserControl<SendMessageViewModel>, ISendMessageView
    {
        public event EventHandler<IdEventArgs> PageLoad;
        public event EventHandler<IdEventArgs> ClassSelected;
        public event EventHandler<SendMessageEventArgs> SendClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Context.User.Identity.GetUserId();
                var ev = new IdEventArgs(id);
                this.PageLoad?.Invoke(sender, ev);

                this.LoadClasses();
            }
        }

        protected void Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classId = this.Classes.SelectedValue;
            if (classId != null || classId != "")
            {
                var ev = new IdEventArgs(classId);
                this.ClassSelected?.Invoke(sender, ev);

                this.LoadStudents();
                this.messageContent.Visible = true;
                return;
            }

            this.messageContent.Visible = false;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var messageContent = this.content.InnerText;
            if (messageContent.Length > Utils.Constants.ContentMaxLength)
            {
                this.MessageContainer.ShowError(Utils.Constants.ContentErrorMessage);
                return;
            }

            var studentId = this.Students.SelectedValue;
            if (studentId == null || studentId == "")
            {
                // Show error
                return;
            }

            var messageDTO = new MessageDTO()
            {
                Content = messageContent
            };

            var teacherId = Context.User.Identity.GetUserId();
            var ev = new SendMessageEventArgs(teacherId, studentId, messageDTO);
            this.SendClick?.Invoke(sender, ev);

            if (this.Model.IsSuccess)
            {
                this.MessageContainer.ShowSuccess("Message send to parents.");
            }
            else
            {
                this.MessageContainer.ShowError(this.Model.ErrorMessage);
            }

        }

        private void LoadStudents()
        {
            this.Classes.Items.Clear();
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
            this.Classes.Items.Add(new ListItem("Choose class"));
            foreach (var cl in this.Model.Classes)
            {
                var item = new ListItem(cl.Name, cl.Id);
                this.Classes.Items.Add(item);
            }
        }
    }
}