using System;
using System.Collections.Generic;

namespace E_School_Diary.WebClient.Models.ViewModels.Register
{
    public class RegisterStudentViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Tuple<string, string>> Classes { get; set; }

        public ICollection<Tuple<string, string>> Teachers { get; set; }
    }
}