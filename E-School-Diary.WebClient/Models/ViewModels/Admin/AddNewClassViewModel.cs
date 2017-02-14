using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Admin
{
    public class AddNewClassViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<MinTeacherInfoDTO> FreeTeachers { get; set; }
    }
}