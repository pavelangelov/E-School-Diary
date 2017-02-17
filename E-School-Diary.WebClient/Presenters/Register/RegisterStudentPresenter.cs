using System;
using System.Linq;

using Microsoft.AspNet.Identity;
using WebFormsMvp;

using E_School_Diary.Data.Enums;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Views.Register;

namespace E_School_Diary.WebClient.Presenters.Register
{
    public class RegisterStudentPresenter : Presenter<IRegisterStudentView>
    {
        private IStudentClassService studentClassService;
        private ITeacherService teacherService;
        private IAppicationUserFactory appUserFactory;

        public RegisterStudentPresenter(IRegisterStudentView view, IStudentClassService studentClassService, ITeacherService teacherService, IAppicationUserFactory appUserFactory)
            : base(view)
        {
            Validator.ValidateForNull(studentClassService, "studentClassService");
            Validator.ValidateForNull(teacherService, "teacherService");
            Validator.ValidateForNull(appUserFactory, "appUserFactory");

            this.studentClassService = studentClassService;
            this.teacherService = teacherService;
            this.appUserFactory = appUserFactory;

            this.View.PageLoad += View_PageLoad;
            this.View.SubmitClick += View_SubmitClick;
        }

        public void View_PageLoad(object sender, RegisterStudentPageLoadEventArgs e)
        {
            // TODO: Replace this with event
            var message = this.ValidateTeacher(e.UserId);
            if (message != null)
            {
                this.View.Model.ErrorMessage = message;
                return;
            }
        }

        public void View_SubmitClick(object sender, RegisterStudentSubmitEventArgs e)
        {
            var user = e.StudentDTO;
            var studentClass = this.studentClassService.FindByTeacherId(user.FormMasterId);
            user.StudentClassId = studentClass.Id;
            
            try
            {
                var appUser = this.appUserFactory.CreateStudent(user);
                IdentityResult result = e.Manager.Create(appUser, user.Password);

                if (result.Succeeded)
                {
                    var currentUser = e.Manager.FindByName(appUser.UserName);

                    var roleresult = e.Manager.AddToRole(currentUser.Id, "Student");

                    this.View.Model.IsSuccess = true;
                }
                else
                {
                    this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
                    this.View.Model.IsSuccess = false;
                }
            }
            catch (ArgumentException ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
            }
        }

        public string ValidateTeacher(string userId)
        {
            var teacher = this.teacherService.FindById(userId);
            if (teacher.UserType != UserTypes.Teacher)
            {
                return "Only Teachers can add studnets!";
            }
            else if (teacher.IsFreeTeacher == true)
            {
                return "Only Teachers with class can add new Student!";
            }

            this.View.Model.TeacherInfo = new TeacherInforForRegisterStudentDTO
            {
                TeacherId = teacher.Id,
                TeacherNames = teacher.FirstName + " " + teacher.LastName
            };

            return null;
        }
    }
}