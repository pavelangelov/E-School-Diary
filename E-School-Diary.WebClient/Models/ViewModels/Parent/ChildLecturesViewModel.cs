using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Parent
{
    public class ChildLecturesViewModel : BaseViewModel
    {
        public string ChildId { get; set; }

        public IEnumerable<LectureDTO> AheadLectures { get; set; }

        public IEnumerable<LectureDTO> CanceledLectures { get; set; }

        public IEnumerable<LectureDTO> PastLectures { get; set; }
    }
}