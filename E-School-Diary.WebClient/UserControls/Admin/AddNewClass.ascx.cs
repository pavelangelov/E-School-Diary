using E_School_Diary.WebClient.Models.ViewModels.Admin;
using E_School_Diary.WebClient.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using E_School_Diary.WebClient.Models.CustomEventArgs.Admin;
using E_School_Diary.WebClient.Presenters.Admin;
using WebFormsMvp;

namespace E_School_Diary.WebClient.UserControls.Admin
{
    [PresenterBinding(typeof(AddNewClassPresenter))]
    public partial class AddNewClass : MvpUserControl<AddNewClassViewModel>, IAddNewClassView
    {
        public event EventHandler<AddNewClassEventArgs> CreateClassClick;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateClass(object sender, EventArgs e)
        {
            // TODO: Validate class name for length and unique
            var className = this.ClassName.Text;
            if (className.Length < 2 || 15 < className.Length)
            {
                this.Error.Text = "Class name must be between 2 and 15 symbols.";
                this.errorContainer.Visible = true;
                this.successContainer.Visible = false;
            }

            this.CreateClassClick?.Invoke(sender, new AddNewClassEventArgs(className));
            if (this.Model.IsSuccess)
            {
                this.Success.Text = "Class created successfully.";
                this.successContainer.Visible = true;
                this.errorContainer.Visible = false;
            }
            else
            {
                this.Error.Text = this.Model.ErrorMessage;
                this.errorContainer.Visible = true;
                this.successContainer.Visible = false;
            }
        }
    }
}