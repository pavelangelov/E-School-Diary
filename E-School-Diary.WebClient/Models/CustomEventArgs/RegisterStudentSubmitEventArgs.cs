using E_School_Diary.Models.DTOs.RegisterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class RegisterStudentSubmitEventArgs : EventArgs
    {
        public RegisterStudentSubmitEventArgs(RegisterStudentDTO studentDTO)
        {
            this.StudentDTO = studentDTO;
        }

        public RegisterStudentDTO StudentDTO { get; set; }
    }
}