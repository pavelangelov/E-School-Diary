using System;
using System.Linq;

using Microsoft.AspNet.Identity;

using WebFormsMvp;

using E_School_Diary.Models.Enums;
using E_School_Diary.WebClient.Models;
using E_School_Diary.WebClient.Views.Admin.Register;
using E_School_Diary.WebClient.Models.CustomEventArgs;

namespace E_School_Diary.WebClient.Presenters.Admin.Register
{
    public class RegisterTeacherPresenter : Presenter<IRegisterTeacherView>
    {
        private ApplicationUserManager manager;
        
        public RegisterTeacherPresenter(IRegisterTeacherView view)
            : base(view)
        {
            this.View.RegisterTeacherClick += View_RegisterTeacherClick;
        }

        private void View_RegisterTeacherClick(object sender, RegisterTeacherEventArgs e)
        {
            var user = new ApplicationUser()
            {
                UserName = e.Email,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Subject = (Subject)Enum.Parse(typeof(Subject), e.SubjectName),
                ImageUrl = "/Images/default-user.png"
            };

            IdentityResult result = e.Manager.Create(user, e.Password);
            if (result.Succeeded)
            {
                var currentUser = e.Manager.FindByName(user.UserName);

                var roleresult = e.Manager.AddToRole(currentUser.Id, "Teacher");

                this.View.Model.IsSuccess = true;
                this.View.Model.User = user;
            }
            else
            {
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
                this.View.Model.IsSuccess = false;
            }
        }
    }
}