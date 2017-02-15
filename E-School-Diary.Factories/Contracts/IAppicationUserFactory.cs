using E_School_Diary.Auth;
using E_School_Diary.Utils.DTOs.RegisterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Factories.Contracts
{
    public interface IAppicationUserFactory
    {
        ApplicationUser CreateStudent(RegisterStudentDTO studentDTO);
    }
}
