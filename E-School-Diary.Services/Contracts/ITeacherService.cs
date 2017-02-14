using System.Collections.Generic;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Services.Contracts
{
    public interface ITeacherService
    {
        IEnumerable<User> GetAll();

        void Add(User entity);

        int Save();
    }
}
