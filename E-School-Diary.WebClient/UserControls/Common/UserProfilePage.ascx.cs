using System;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;
using System.IO;

namespace E_School_Diary.WebClient.UserControls.Common
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class UserProfilePage : MvpUserControl<ProfileViewModel>, IProfileView
    {
        public event EventHandler<FileUploadEventArgs> FileUploadClick;
        public event EventHandler<IdEventArgs> PageLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Context.User.Identity.GetUserId();
                var ev = new IdEventArgs(id);

                this.PageLoad?.Invoke(sender, ev);
            }
        }

        protected void UploadImage(object sender, EventArgs e)
        {
            var selectedFile = this.file.PostedFile;
            this.FileError.InnerText = "";

            if (selectedFile != null && selectedFile.ContentLength < 500000)
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
            }
            else
            {
                this.FileError.InnerText = "File must be less tha 5Kb.";
            }
        }
    }
}