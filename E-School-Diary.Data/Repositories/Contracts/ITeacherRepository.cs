using E_School_Diary.Data.DB;
using System.Linq;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface ITeacherRepository
    {
        IQueryable<AspNetUsers1> GetAll();

        void Add(AspNetUsers1 entity);

        int Save();
    }
}
