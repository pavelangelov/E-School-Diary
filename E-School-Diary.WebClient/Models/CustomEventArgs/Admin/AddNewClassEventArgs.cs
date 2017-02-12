using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Admin
{
    public class AddNewClassEventArgs : EventArgs
    {
        public AddNewClassEventArgs(string className)
        {
            this.ClassName = className;
        }

        public string ClassName { get; set; }
    }
}