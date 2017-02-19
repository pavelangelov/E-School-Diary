using System;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class SendMessageEventArgs : EventArgs
    {
        public SendMessageEventArgs(string teacherId, string studentId, MessageDTO messageDTO)
        {
            this.TeacherId = teacherId;
            this.StudentId = studentId;
            this.MessageDTO = messageDTO;
        }

        public string TeacherId { get; set; }

        public string StudentId { get; set; }

        public MessageDTO MessageDTO { get; set; }
    }
}