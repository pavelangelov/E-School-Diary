using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Admin
{
    public class AddNewClassViewModel : BaseViewModel
    {
        public IEnumerable<MinTeacherInfoDTO> FreeTeachers { get; set; }
    }
}