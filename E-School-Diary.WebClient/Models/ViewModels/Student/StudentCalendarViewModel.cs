using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Student
{
    public class StudentCalendarViewModel : BaseViewModel
    {
        public string LastCheckedDate { get; set; }

        public IEnumerable<LectureDTO> AheadLectures { get; set; }

        public IEnumerable<LectureDTO> CanceledLectures { get; set; }

        public IEnumerable<LectureDTO> PastLectures { get; set; }
    }
}