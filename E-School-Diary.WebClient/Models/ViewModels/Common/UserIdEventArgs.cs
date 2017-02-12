using System;

namespace E_School_Diary.WebClient.Models.ViewModels.Common
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