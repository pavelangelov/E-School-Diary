using System;
using WebFormsMvp;

using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.WebClient.Views.Admin;

namespace E_School_Diary.WebClient.Presenters.Admin
{
    public class AddNewClassPresenter : Presenter<IAddNewClassView>
    {
        private IStudentClassService studentClassService;

        public AddNewClassPresenter(IAddNewClassView view, IStudentClassService stClassService)
            : base(view)
        {
            this.studentClassService = stClassService;

            this.View.CreateClassClick += View_CreateClassClick;
        }

        private void View_CreateClassClick(object sender, Models.CustomEventArgs.Admin.AddNewClassEventArgs e)
        {
            var stClass = new StudentClass() { Name = e.ClassName, Id = Guid.NewGuid().ToString() };
            int changes = 0;
            try
            {
                this.studentClassService.Add(stClass);
                changes = this.studentClassService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something`s wrong. Maybe this class already exist.";
                return;
            }

            if (changes <= 0)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something is wrong!";
            }
            else
            {
                this.View.Model.IsSuccess = true;
            }
        }
    }
}