using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class ChangeLectureStatusEventArgs : EventArgs
    {
        public ChangeLectureStatusEventArgs(string lectureId, string lectureStatus)
        {
            this.LectureId = lectureId;
            this.LectureStatus = lectureStatus;
        }

        public string LectureId { get; set; }

        public string LectureStatus { get; set; }
    }
}