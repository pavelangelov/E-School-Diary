using System;

using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Views.Common;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace E_School_Diary.WebClient.Presenters.Common
{
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private IUserService userService;
        private IImageUploadService imageUploadService;

        public ProfilePresenter(IProfileView view, IUserService userService, IImageUploadService imageUploadService)
            : base(view)
        {
            Validator.ValidateForNull(userService, "userService");
            Validator.ValidateForNull(imageUploadService, "imageUploadService");

            this.userService = userService;
            this.imageUploadService = imageUploadService;

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
            var user = this.userService.FindById(e.UserId);
            var uploader = this.imageUploadService.GetUploader();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(e.FilePath),
                Transformation = new Transformation().Gravity("face")
            };

            var uploadResult = uploader.Upload(uploadParams);
            if (uploadResult.Error == null)
            {
                string url = uploadResult.SecureUri.OriginalString;
                user.ImageUrl = url;
                try
                {
                    this.userService.Save();
                }
                catch (Exception)
                {
                    this.View.Model.IsSuccess = false;
                    this.View.Model.ErrorMessage = "Cannot apply image for this user.";
                    return;
                }
                
                this.View.Model.IsSuccess = true;
            }
            else
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = uploadResult.Error.Message;
            }
        }
    }
}