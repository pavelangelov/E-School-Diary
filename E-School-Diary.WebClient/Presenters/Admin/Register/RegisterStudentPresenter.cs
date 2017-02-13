using E_School_Diary.WebClient.Views.Admin.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using System.Web.Caching;
using System.Web.Routing;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.WebClient.Models;
using Microsoft.AspNet.Identity;

namespace E_School_Diary.WebClient.Presenters.Admin.Register
{
    public class RegisterStudentPresenter : Presenter<IRegisterStudentView>
    {
        private ApplicationUserManager manager;
        private IStudentClassRepository classesRepository;
        private ITeacherRepository teacherRepository;

        public RegisterStudentPresenter(IRegisterStudentView view, IStudentClassRepository classesRepository, ITeacherRepository teacherRepository)
            : base(view)
        {
            this.classesRepository = classesRepository;
            this.teacherRepository = teacherRepository;

            this.View.PageLoad += View_PageLoad;
            this.View.SubmitClick += View_SubmitClick;
        }

        private void View_PageLoad(object sender, RegisterStudentPageLoadEventArgs e)
        {
            this.manager = e.Manager;
            this.GetStudentClasses();
            this.GetTeachers();
        }

        private void GetStudentClasses()
        {
            //var classes = this.classesRepository.GetAll()
            //                                    .ToList()
            //                                    .Select(x => new Tuple<string, string>(x.Name, x.Id))
            //                                    .OrderBy(x => x.Item1)
            //                                    .ToList();


            //this.View.Model.Classes = classes;
        }

        private void GetTeachers()
        {
            //var teachers = this.teacherRepository.GetAll()
            //                        .ToList()
            //                        .Select(x => new Tuple<string, string>(x.FirstName + " " + x.LastName, x.Id))
            //                        .ToList();

            //this.View.Model.Teachers = teachers;
        }

        private void View_SubmitClick(object sender, RegisterStudentSubmitEventArgs e)
        {
            var user = e.StudentDTO;
            var appUser = new ApplicationUser()
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FormMasterId = user.FormMasterId,
                StudentClassId = user.StudentClassId,
                Age = user.Age,
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