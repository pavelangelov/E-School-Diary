using System;

using E_School_Diary.Models.DTOs.RegisterDTOs;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class RegisterTeacherEventArgs : EventArgs
    {
        public RegisterTeacherEventArgs(RegisterTeacherDTO teacherDTO, ApplicationUserManager manager)
        {
            this.TeacherDTO = teacherDTO;
            this.Manager = manager;
        }

        public RegisterTeacherDTO TeacherDTO { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}