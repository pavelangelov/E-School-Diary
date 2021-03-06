﻿using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class AddMarksViewModel : BaseViewModel
    {
        public IEnumerable<StudentClassDTO> Classes { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }
    }
}