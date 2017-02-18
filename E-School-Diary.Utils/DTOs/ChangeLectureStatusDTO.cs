using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Utils.DTOs
{
    public class ChangeLectureStatusDTO
    {
        public string Id { get; set; }

        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public string Status { get; set; }

        public string ClassName { get; set; }

        public string Title { get; set; }
    }
}
