using WebFormsMvp;

using E_School_Diary.WebClient.Views.Common;

namespace E_School_Diary.WebClient.Presenters.Common
{
    public class NavigationPresenter : Presenter<INavigationView>
    {
        public NavigationPresenter(INavigationView view) 
            : base(view)
        {
            this.View.NavigationLoad += View_NavigationLoad;
        }

        private void View_NavigationLoad(object sender, Models.CustomEventArgs.NavigationEventArgs e)
        {
            var status = e.Manager.FindByIdAsync(e.UserId);

            if (status.Result != null)
            {
                var user = status.Result;
                this.View.Model.Email = user.Email;
                this.View.Model.FirstName = user.FirstName;
                this.View.Model.LastName = user.LastName;
                this.View.Model.ImageUrl = user.ImageUrl;
            }
        }
    }
}