using System.Linq;

using E_School_Diary.Data.EF_DataSource;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface ITeacherRepository
    {
        IQueryable<User> GetAll();

        void Add(User entity);

        int Save();
    }
}
