using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class RegisterStudentPageLoadEventArgs : EventArgs
    {
        public RegisterStudentPageLoadEventArgs(string userId, ApplicationUserManager manager)
        {
            this.UserId = userId;
            this.Manager = manager;
        }

        public string UserId { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}