using E_School_Diary.Utils.DTOs.RegisterDTOs;
using System;
using System.Collections.Generic;

namespace E_School_Diary.WebClient.Models.ViewModels.Register
{
    public class RegisterStudentViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public TeacherInforForRegisterStudentDTO TeacherInfo { get; set; }

        public ICollection<Tuple<string, string>> Classes { get; set; }

        public ICollection<Tuple<string, string>> Teachers { get; set; }
    }
}