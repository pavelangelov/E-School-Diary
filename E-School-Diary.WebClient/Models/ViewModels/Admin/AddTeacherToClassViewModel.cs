using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Admin
{
    public class AddTeacherToClassViewModel : BaseViewModel
    {
        public IEnumerable<MinTeacherInfoDTO> Teachers { get; set; }

        public IEnumerable<StudentClassDTO> AvailableClasses { get; set; }
    }
}