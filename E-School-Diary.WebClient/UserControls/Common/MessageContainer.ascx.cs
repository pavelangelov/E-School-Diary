using System;
using System.Web.UI;

namespace E_School_Diary.WebClient.UserControls.Common
{
    public partial class MessageContainer : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ShowSuccess(string message)
        {
            this.Success.Text = message;
            this.successContainer.Visible = true;

            this.Error.Text = "";
            this.errorContainer.Visible = false;
        }

        public void ShowError(string message)
        {
            this.Error.Text = message;
            this.errorContainer.Visible = true;

            this.Success.Text = "";
            this.successContainer.Visible = false;
        }

        public void ClearAll()
        {
            this.Success.Text = "";
            this.Error.Text = "";

            this.successContainer.Visible = false;
            this.errorContainer.Visible = false;
        }
    }
}