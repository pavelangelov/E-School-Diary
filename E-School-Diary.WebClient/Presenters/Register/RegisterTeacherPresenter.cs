using System;
using System.Linq;

using Microsoft.AspNet.Identity;
using WebFormsMvp;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Views.Register;

namespace E_School_Diary.WebClient.Presenters.Register
{
    public class RegisterTeacherPresenter : Presenter<IRegisterTeacherView>
    {
        private IAppicationUserFactory appUserFactory;

        public RegisterTeacherPresenter(IRegisterTeacherView view, IAppicationUserFactory appUserFactory)
            : base(view)
        {
            Validator.ValidateForNull(appUserFactory, "appUserFactory");

            this.appUserFactory = appUserFactory;

            this.View.RegisterTeacherClick += View_RegisterTeacherClick;
        }

        public void View_RegisterTeacherClick(object sender, RegisterTeacherEventArgs e)
        {

            try
            {
                var user = this.appUserFactory.CreateTeacher(e.TeacherDTO);
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
            catch (ArgumentException ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.IsSuccess = false;
            }
        }
    }
}