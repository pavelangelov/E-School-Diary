using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Register
{
    public class RegisterStudentPageLoadEventArgs : EventArgs
    {
        public RegisterStudentPageLoadEventArgs(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; set; }
    }
}