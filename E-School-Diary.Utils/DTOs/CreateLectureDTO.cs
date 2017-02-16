using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Utils.DTOs
{
    public class CreateLectureDTO
    {
        public string Title { get; set; }

        public string TeacherId { get; set; }

        public string StudentClassId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string SubjectName { get; set; }
    }
}
