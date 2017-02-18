using System.Collections.Generic;

using E_School_Diary.Utils.DTOs;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class ChangeLectureStatusViewModel : BaseViewModel
    {
        public IEnumerable<ChangeLectureStatusDTO> Lectures { get; set; }
    }
}