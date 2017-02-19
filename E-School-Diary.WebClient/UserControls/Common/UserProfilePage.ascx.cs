using System;

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
            if (!IsPostBack)
            {
                var id = Context.User.Identity.GetUserId();
                var ev = new IdEventArgs(id);

                this.PageLoad?.Invoke(sender, ev);
            }
        }

        protected void UploadImage(object sender, EventArgs e)
        {

        }
    }
}