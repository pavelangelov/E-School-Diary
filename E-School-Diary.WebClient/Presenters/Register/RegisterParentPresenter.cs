using System;
using System.Linq;

using Microsoft.AspNet.Identity;
using WebFormsMvp;

using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Register;
using E_School_Diary.WebClient.Views.Register;

namespace E_School_Diary.WebClient.Presenters.Register
{
    public class RegisterParentPresenter : Presenter<IRegisterParentView>
    {

        private IStudentClassService studentClassService;
        private IStudentService studentService;
        private IAppicationUserFactory userFactory;


        public RegisterParentPresenter(IRegisterParentView view, IStudentClassService studentClassService, IStudentService studentService, IAppicationUserFactory userFactory)
            : base(view)
        {
            Validator.ValidateForNull(studentClassService, "studentClassService");
            Validator.ValidateForNull(studentService, "studentService");
            Validator.ValidateForNull(userFactory, "userFactory");

            this.studentClassService = studentClassService;
            this.studentService = studentService;
            this.userFactory = userFactory;

            this.View.PageLoad += View_PageLoad;
            this.View.StudentClassSelected += View_StudentClassSelected;
            this.View.RegisterParentClick += View_RegisterParentClick;
        }

        private void View_PageLoad(object sender, EventArgs e)
        {
            var classes = this.studentClassService.GetAll()
                                                    .Select(cl => new StudentClassDTO()
                                                    {
                                                        Id = cl.Id,
                                                        Name = cl.Name
                                                    })
                                                    .ToList();
            classes.Sort();
            this.View.Model.Classes = classes;
        }

        private void View_StudentClassSelected(object sender, IdEventArgs e)
        {
            var students = this.studentService.FindByStudentClassId(e.Id)
                                                .Select(st => new StudentDTO()
                                                {
                                                    Id = st.Id,
                                                    FirstName = st.FirstName,
                                                    MiddleName = st.MiddleName,
                                                    LastName = st.LastName
                                                })
                                                .OrderBy(st => st.FirstName + st.LastName);

            this.View.Model.Students = students;
        }

        private void View_RegisterParentClick(object sender, RegisterParentClickEventArgs e)
        {
            try
            {
                var appUser = this.userFactory.CreateParent(e.ParentDTO);
                IdentityResult result = e.Manager.Create(appUser, e.ParentDTO.Password);

                if (result.Succeeded)
                {
                    var currentUser = e.Manager.FindByName(appUser.UserName);

                    var roleresult = e.Manager.AddToRole(currentUser.Id, "Parent");

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
    }
}