using E_School_Diary.Utils.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class ChangeLectureStatusViewModel
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<ChangeLectureStatusDTO> Lectures { get; set; }
    }
}