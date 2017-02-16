using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class SelectClassEventArgs : EventArgs
    {
        public SelectClassEventArgs(string teacherId, string classId)
        {
            this.TeacherId = teacherId;
            this.ClassId = classId;
        }

        public string TeacherId { get; set; }

        public string ClassId { get; set; }
    }
}