using System;
using System.Web.UI;

namespace E_School_Diary.WebClient.UserControls.Registration
{
    public partial class Common : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string RegistrationTitle
        {
            get
            {
                return this.Title.InnerText;
            }

            set
            {
                this.Title.InnerText = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.FirstNameInput.Text;
            }
        }

        public string LastName
        {
            get
            {
                return this.LastNameInput.Text;
            }
        }

        public string Email
        {
            get
            {
                return this.EmailInput.Text;
            }
        }

        public int Age
        {
            get
            {
                return int.Parse(this.AgeInput.Text);
            }
        }

        public string Password
        {
            get
            {
                return this.PasswordInput.Text;
            }
        }

        public void ShowSuccess(string message)
        {
            this.Message.ShowSuccess(message);
        }

        public void ShowError(string message)
        {
            this.Message.ShowError(message);
        }

        public void ClearAll()
        {
            this.Message.ClearAll();
        }
    }
}