using System;

using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.WebClient.Presenters.Common
{
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private IUserService userService;

        public ProfilePresenter(IProfileView view, IUserService userService) 
            : base(view)
        {
            Validator.ValidateForNull(userService, "userService");

            this.userService = userService;

            this.View.PageLoad += View_PageLoad;
            this.View.FileUploadClick += View_FileUploadClick;
        }

        private void View_PageLoad(object sender, IdEventArgs e)
        {
            var user = this.userService.GetMinInfo(e.Id);

            this.View.Model.Names = $"{user.FirstName} {user.MiddleName ?? ""} {user.LastName}";
            this.View.Model.Username = user.Username;
            this.View.Model.ImageUrl = user.ImageUrl;
        }

        private void View_FileUploadClick(object sender, FileUploadEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}