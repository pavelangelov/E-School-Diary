using E_School_Diary.Utils.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Admin
{
    public class AddTeacherToClassViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<MinTeacherInfoDTO> Teachers { get; set; }

        public IEnumerable<StudentClassDTO> AvailableClasses { get; set; }
    }
}