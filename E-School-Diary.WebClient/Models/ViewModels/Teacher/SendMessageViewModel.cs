using E_School_Diary.Utils.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Teacher
{
    public class SendMessageViewModel : BaseViewModel
    {
        public IEnumerable<StudentClassDTO> Classes { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }
    }
}