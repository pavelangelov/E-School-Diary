using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Admin
{
    public class AddNewClassEventArgs : EventArgs
    {
        public AddNewClassEventArgs(string className, string teacherId)
        {
            this.ClassName = className;
            this.TeacherId = teacherId;
        }

        public string ClassName { get; set; }

        public string TeacherId { get; set; }
    }
}