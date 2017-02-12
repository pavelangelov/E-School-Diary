using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Student
{
    public class CalendarEventArgs : EventArgs
    {
        public CalendarEventArgs(string date, string userId)
        {
            this.Date = date;
            this.UserId = userId;
        }

        public string Date { get; set; }

        public string UserId { get; set; }
    }
}