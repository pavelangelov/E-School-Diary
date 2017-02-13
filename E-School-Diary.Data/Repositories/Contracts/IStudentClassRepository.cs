using E_School_Diary.Data.EF_DataSource;
using System.Linq;


namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface IStudentClassRepository
    {
        IQueryable<StudentClass> GetAll();

        void Add(StudentClass entity);

        int Save();
    }
}
