using System.Linq;

using Microsoft.AspNet.Identity;
using WebFormsMvp;

using E_School_Diary.Data.Enums;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.WebClient.Models;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Views.Register;

namespace E_School_Diary.WebClient.Presenters.Register
{
    public class RegisterStudentPresenter : Presenter<IRegisterStudentView>
    {
        private ApplicationUserManager manager;
        private IStudentClassService studentClassService;
        private ITeacherService teacherService;

        public RegisterStudentPresenter(IRegisterStudentView view, IStudentClassService studentClassService, ITeacherService teacherService)
            : base(view)
        {
            this.studentClassService = studentClassService;
            this.teacherService = teacherService;

            this.View.PageLoad += View_PageLoad;
            this.View.SubmitClick += View_SubmitClick;
        }

        private void View_PageLoad(object sender, RegisterStudentPageLoadEventArgs e)
        {
            var message = this.ValidateTeacher(e.UserId);
            if (message != null)
            {
                this.View.Model.ErrorMessage = message;
                return;
            }
        }

        private string ValidateTeacher(string userId)
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

        private void View_SubmitClick(object sender, RegisterStudentSubmitEventArgs e)
        {
            this.manager = e.Manager;
            var user = e.StudentDTO;
            var studentClass = this.studentClassService.GetByTeacherId(user.FormMasterId);
            var appUser = new ApplicationUser()
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentClassId = studentClass.Id,
                Age = user.Age,
                UserType = UserTypes.Student,
                ImageUrl = "/Images/default-user.png"
            };

            IdentityResult result = this.manager.Create(appUser, user.Password);
            if (result.Succeeded)
            {
                var currentUser = this.manager.FindByName(appUser.UserName);

                var roleresult = this.manager.AddToRole(currentUser.Id, "Student");

                this.View.Model.IsSuccess = true;
            }
            else
            {
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
                this.View.Model.IsSuccess = false;
            }
        }
    }
}