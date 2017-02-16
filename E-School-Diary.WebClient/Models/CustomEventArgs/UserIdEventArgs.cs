using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class UserIdEventArgs : EventArgs
    {
        public UserIdEventArgs(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; set; }
    }
}