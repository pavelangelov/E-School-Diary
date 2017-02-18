using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.ViewModels
{
    public class BaseViewModel
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }
    }
}