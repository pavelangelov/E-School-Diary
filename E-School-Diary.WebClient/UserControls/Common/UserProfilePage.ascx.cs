using System;
using System.IO;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.WebClient.UserControls.Common
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class UserProfilePage : MvpUserControl<ProfileViewModel>, IProfileView
    {
        public event EventHandler<FileUploadEventArgs> FileUploadClick;
        public event EventHandler<IdEventArgs> PageLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Context.User.Identity.GetUserId();
            var ev = new IdEventArgs(id);

            this.PageLoad?.Invoke(sender, ev);
        }

        protected void UploadImage(object sender, EventArgs e)
        {
            var selectedFile = this.file.PostedFile;
            if (!selectedFile.ContentType.Contains("image"))
            {
                this.FileError.InnerText = "Invalid file format";
                return;
            }

            this.FileError.InnerText = "";

            if (selectedFile != null && selectedFile.ContentLength <= Utils.Constants.ImageUploadMaxSize)
            {
                var filePath = Server.MapPath($"~/Uploaded_Files/{this.file.FileName}");
                selectedFile.SaveAs(filePath);
                var id = Context.User.Identity.GetUserId();
                var ev = new FileUploadEventArgs(id, filePath, this.file.FileName);

                this.FileUploadClick?.Invoke(sender, ev);
                if (this.Model.IsSuccess)
                {
                    this.Message.ShowSuccess("Image uploaded.");
                }
                else
                {
                    this.Message.ShowError(this.Model.ErrorMessage);
                }

                File.Delete(filePath);
            }
            else
            {
                this.FileError.InnerText = "File must be less tha 500Kb.";
            }
        }
    }
}