using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels.Register
{
    public class RegisterTeacherViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public ApplicationUser User { get; set; }
    }
}