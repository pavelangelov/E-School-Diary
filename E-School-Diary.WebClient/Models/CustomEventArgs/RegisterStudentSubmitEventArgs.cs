using System;

using E_School_Diary.Utils.DTOs.RegisterDTOs;

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