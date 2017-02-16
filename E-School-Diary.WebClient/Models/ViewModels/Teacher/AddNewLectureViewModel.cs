using E_School_Diary.Utils.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class AddNewLectureViewModel
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<Tuple<string, string>> LectureHours { get; set; }

        public IEnumerable<StudentClassDTO> Classes { get; set; }
    }
}