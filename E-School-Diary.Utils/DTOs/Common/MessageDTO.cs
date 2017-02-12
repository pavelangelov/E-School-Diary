using System;

namespace E_School_Diary.Utils.DTOs.Common
{
    public class MessageDTO
    {
        public string Content { get; set; }

        public string From { get; set; }

        public DateTime SendOn { get; set; }
    }
}
