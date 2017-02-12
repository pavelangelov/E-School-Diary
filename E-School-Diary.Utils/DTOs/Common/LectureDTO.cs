using System;

using E_School_Diary.Models.Enums;

namespace E_School_Diary.Utils.DTOs.Common
{
    public class LectureDTO
    {
        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public LectureStatus Status { get; set; }

        public Subject Subject { get; set; }

        public string Title { get; set; }
    }
}
