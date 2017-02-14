using System.Collections.Generic;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Services.Contracts
{
    public interface IStudentClassService
    {
        IEnumerable<StudentClass> GetAll();

        void Add(StudentClass entity);

        int Save();
    }
}
