using System.Collections.Generic;

using E_School_Diary.Data.Models;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services.Contracts
{
    public interface ITeacherService
    {
        IEnumerable<User> GetAll();

        User FindById(string teacherId);

        IEnumerable<MinTeacherInfoDTO> GetTeachersWithoutClass();

        void Add(User entity);

        int Save();
    }
}
