using System;
using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class AddNewLectureViewModel : BaseViewModel
    {
        public IEnumerable<Tuple<string, string>> LectureHours { get; set; }

        public IEnumerable<StudentClassDTO> Classes { get; set; }
    }
}