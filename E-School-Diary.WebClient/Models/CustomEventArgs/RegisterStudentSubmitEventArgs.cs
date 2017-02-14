using System;

using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class RegisterStudentSubmitEventArgs : EventArgs
    {
        public RegisterStudentSubmitEventArgs(RegisterStudentDTO studentDTO, ApplicationUserManager manager)
        {
            this.StudentDTO = studentDTO;
            this.Manager = manager;
        }

        public RegisterStudentDTO StudentDTO { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}