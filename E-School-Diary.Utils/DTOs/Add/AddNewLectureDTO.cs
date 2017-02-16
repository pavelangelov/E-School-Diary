using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Utils.DTOs.Add
{
    public class AddNewLectureDTO
    {
        public string Title { get; set; }

        public string TeacherId { get; set; }

        public string StudentClassId { get; set; }

        public string Date { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string SubjectName { get; set; }
    }
}
