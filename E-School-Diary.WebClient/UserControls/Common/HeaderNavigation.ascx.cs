using E_School_Diary.WebClient.Models.ViewModels.Common;
using E_School_Diary.WebClient.Views.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using Microsoft.AspNet.Identity.Owin;
using E_School_Diary.WebClient.Presenters.Common;
using WebFormsMvp;

namespace E_School_Diary.WebClient.UserControls.Common
{
    [PresenterBinding(typeof(NavigationPresenter))]
    public partial class HeaderNavigation : MvpUserControl<NavigationViewModel>, INavigationView
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