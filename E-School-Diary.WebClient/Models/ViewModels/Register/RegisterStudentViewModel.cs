using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.WebClient.Models.ViewModels.Register
{
    public class RegisterStudentViewModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public TeacherInforForRegisterStudentDTO TeacherInfo { get; set; }
    }
}