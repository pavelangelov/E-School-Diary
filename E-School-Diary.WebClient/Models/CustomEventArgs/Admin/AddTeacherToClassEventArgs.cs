using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Admin
{
    public class AddTeacherToClassEventArgs : EventArgs
    {
        public AddTeacherToClassEventArgs(string teacherId, string classId)
        {
            this.TeacherId = teacherId;
            this.ClassId = classId;
        }

        public string TeacherId { get; set; }

        public string ClassId { get; set; }
    }
}