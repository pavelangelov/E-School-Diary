using System;

using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.ViewModels.Parent;
using E_School_Diary.WebClient.Presenters.Parent;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.WebClient.UserControls.Parent
{
    [PresenterBinding(typeof(ParentMessagesPresenter))]
    public partial class Messages : MvpUserControl<ParentMessagesViewModel>, IParentMessagesView
    {
        public event EventHandler<IdEventArgs> PageLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Context.User.Identity.GetUserId();
                var ev = new IdEventArgs(id);

                this.PageLoad?.Invoke(sender, ev);

                this.MessagesContainer.DataSource = this.Model.Messages;
                this.MessagesContainer.DataBind();
            }
        }
    }
}