using System;

using E_School_Diary.Auth;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class NavigationEventArgs : EventArgs
    {
        public NavigationEventArgs(string userId, ApplicationUserManager manager)
        {
            this.UserId = userId;
            this.Manager = manager;
        }

        public string UserId { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}