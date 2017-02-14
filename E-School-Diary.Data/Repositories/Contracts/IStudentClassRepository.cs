using System.Linq;
using E_School_Diary.Data.CustomModels.Models;


namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface IStudentClassRepository
    {
        IQueryable<StudentClass> GetAll();

        void Add(StudentClass entity);

        int Save();
    }
}
