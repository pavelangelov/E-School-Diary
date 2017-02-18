using System;

using E_School_Diary.Auth;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Register
{
    public class RegisterParentClickEventArgs : EventArgs
    {
        public RegisterParentClickEventArgs(RegisterParentDTO parentDTO, ApplicationUserManager manager)
        {
            this.ParentDTO = parentDTO;
            this.Manager = manager;
        }

        public RegisterParentDTO ParentDTO { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}