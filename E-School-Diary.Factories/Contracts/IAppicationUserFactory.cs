using E_School_Diary.Auth;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Factories.Contracts
{
    public interface IAppicationUserFactory
    {
        ApplicationUser CreateStudent(RegisterStudentDTO studentDTO);

        ApplicationUser CreateTeacher(RegisterTeacherDTO teacherDTO);

        ApplicationUser CreateParent(RegisterParentDTO parentDTO);
    }
}
