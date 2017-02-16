using System;
using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Add;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class AddMarksEventArgs : EventArgs
    {
        public AddMarksEventArgs(string teacherId, AddMarkDTO mark)
        {
            this.TeacherId = teacherId;
            this.Mark = mark;
        }

        public string TeacherId { get; set; }

        public AddMarkDTO Mark { get; set; }
    }
}