using System;

using E_School_Diary.Utils.DTOs.RegisterDTOs;
using E_School_Diary.Auth;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Register
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