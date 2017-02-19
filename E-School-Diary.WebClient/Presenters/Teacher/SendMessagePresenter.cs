using System;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.Presenters.Teacher
{
    public class SendMessagePresenter : Presenter<ISendMessageView>
    {
        private ITeacherService teacherService;
        private IStudentService studentService;
        private IParentService parentService;
        private IMessageFactory messageFactory;

        public SendMessagePresenter(ISendMessageView view, ITeacherService teacherService, IStudentService studentService, IParentService parentService, IMessageFactory messageFactory) 
            : base(view)
        {
            Validator.ValidateForNull(teacherService, "teacherService");
            Validator.ValidateForNull(studentService, "studentService");
            Validator.ValidateForNull(parentService, "parentService");
            Validator.ValidateForNull(messageFactory, "messageFactory");

            this.teacherService = teacherService;
            this.studentService = studentService;
            this.parentService = parentService;
            this.messageFactory = messageFactory;

            this.View.PageLoad += View_PageLoad;
            this.View.ClassSelected += View_ClassSelected;
            this.View.SendClick += View_SendClick;
        }

        private void View_PageLoad(object sender, IdEventArgs e)
        {
            var classes = this.teacherService.GetTeacherClasses(e.Id)
                                               .OrderBy(cl => cl.Name);

            this.View.Model.Classes = classes;
        }

        private void View_ClassSelected(object sender, IdEventArgs e)
        {
            var students = this.studentService.FindByStudentClassId(e.Id)
                                                .OrderBy(st => st.FirstName)
                                                .ThenBy(st => st.LastName);

            this.View.Model.Students = students;
        }

        private void View_SendClick(object sender, SendMessageEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.TeacherId);
            var parents = this.parentService.FindParents(e.StudentId);

            if (parents.Count() < 1)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "This student doesn`t have registred parents!";
                return;
            }

            var messageDto = e.MessageDTO;
            messageDto.From = $"{teacher.FirstName} {teacher.MiddleName ?? ""} {teacher.LastName}";
            messageDto.SendOn = DateTime.Now;

            try
            {
                foreach (var parent in parents)
                {
                    var msg = this.messageFactory.CreateMessage(messageDto);
                    parent.Messages.Add(msg);
                }
            }
            catch (ArgumentException ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = ex.Message;
                return;
            }

            try
            {
                this.parentService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Error while updating parents messages.";
                return;
            }

            this.View.Model.IsSuccess = true;
        }
    }
}