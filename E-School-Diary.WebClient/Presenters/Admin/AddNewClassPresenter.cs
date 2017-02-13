using E_School_Diary.Data.EF_DataSource;
using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.WebClient.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Presenters.Admin
{
    public class AddNewClassPresenter : Presenter<IAddNewClassView>
    {
        private IStudentClassRepository stClassRepository;

        public AddNewClassPresenter(IAddNewClassView view, IStudentClassRepository stClassRepository)
            : base(view)
        {
            this.stClassRepository = stClassRepository;

            this.View.CreateClassClick += View_CreateClassClick;
        }

        private void View_CreateClassClick(object sender, Models.CustomEventArgs.Admin.AddNewClassEventArgs e)
        {
            var stClass = new StudentClass() { Name = e.ClassName, Id = Guid.NewGuid().ToString() };
            int changes = 0;
            try
            {
                this.stClassRepository.Add(stClass);
                changes = this.stClassRepository.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = ex.Message;
                return;
            }

            if (changes <= 0)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something is wrong!";
            }
        }
    }
}