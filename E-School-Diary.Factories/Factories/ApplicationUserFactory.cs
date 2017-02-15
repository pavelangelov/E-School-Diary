using E_School_Diary.Auth;
using E_School_Diary.Data.Enums;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Factories
{
    public class ApplicationUserFactory : IAppicationUserFactory
    {
        public ApplicationUser CreateStudent(RegisterStudentDTO studentDTO)
        {
            var appUser = new ApplicationUser()
            {
                UserName = studentDTO.Email,
                Email = studentDTO.Email,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                StudentClassId = studentDTO.StudentClassId,
                Age = studentDTO.Age,
                UserType = UserTypes.Student,
                ImageUrl = Constants.DefaultUserImage
            };

            return appUser;
        }
    }
}
