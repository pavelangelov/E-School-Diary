using System;
using System.Linq;

using Microsoft.AspNet.Identity;

using WebFormsMvp;

using E_School_Diary.Data.Enums;
using E_School_Diary.WebClient.Models;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Views.Register;
using E_School_Diary.Auth;

namespace E_School_Diary.WebClient.Presenters.Register
{
    public class RegisterTeacherPresenter : Presenter<IRegisterTeacherView>
    {   
        public RegisterTeacherPresenter(IRegisterTeacherView view)
            : base(view)
        {
            this.View.RegisterTeacherClick += View_RegisterTeacherClick;
        }

        private void View_RegisterTeacherClick(object sender, RegisterTeacherEventArgs e)
        {
            var user = new ApplicationUser()
            {
                UserName = e.TeacherDTO.Email,
                Email = e.TeacherDTO.Email,
                FirstName = e.TeacherDTO.FirstName,
                LastName = e.TeacherDTO.LastName,
                Age = e.TeacherDTO.Age,
                UserType = UserTypes.Teacher,
                IsFreeTeacher = true,
                Subject = (Subject)Enum.Parse(typeof(Subject), e.TeacherDTO.Subject),
                ImageUrl = "/Images/default-user.png"
            };

            IdentityResult result = e.Manager.Create(user, e.TeacherDTO.Password);
            if (result.Succeeded)
            {
                var currentUser = e.Manager.FindByName(user.UserName);

                var roleresult = e.Manager.AddToRole(currentUser.Id, "Teacher");

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