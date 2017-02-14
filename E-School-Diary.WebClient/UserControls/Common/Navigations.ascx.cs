using System;
using System.Web;
using System.Web.Security;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Presenters.Common;
using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.WebClient.UserControls.Common
{
    [PresenterBinding(typeof(NavigationPresenter))]
    public partial class Navigations : MvpUserControl<NavigationViewModel>, INavigationView
    {
        public event EventHandler<NavigationEventArgs> NavigationLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var userId = Context.User.Identity.GetUserId();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                this.NavigationLoad?.Invoke(sender, new NavigationEventArgs(userId, manager));

            }
        }

        protected void Unnamed_LoggingOut(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("/");
        }
    }
}