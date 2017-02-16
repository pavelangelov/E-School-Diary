using System;
using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Add;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class AddMarksEventArgs : EventArgs
    {
        public AddMarksEventArgs(string teacherId, IEnumerable<AddMarkDTO> marks)
        {
            this.TeacherId = teacherId;
            this.Marks = marks;
        }

        public string TeacherId { get; set; }

        public IEnumerable<AddMarkDTO> Marks { get; set; }
    }
}