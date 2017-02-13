using System;

namespace E_School_Diary.Utils.DTOs.Common
{
    public class LectureDTO
    {
        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public string Status { get; set; }

        public string Subject { get; set; }

        public string Title { get; set; }
    }
}
