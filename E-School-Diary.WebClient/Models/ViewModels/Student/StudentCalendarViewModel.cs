using E_School_Diary.Utils.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Student
{
    public class StudentCalendarViewModel
    {
        public string LastCheckedDate { get; set; }

        public IEnumerable<LectureDTO> AheadLectures { get; set; }

        public IEnumerable<LectureDTO> CanceledLectures { get; set; }

        public IEnumerable<LectureDTO> PastLectures { get; set; }
    }
}