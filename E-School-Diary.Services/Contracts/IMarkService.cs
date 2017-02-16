using E_School_Diary.Data.Models;

namespace E_School_Diary.Services.Contracts
{
    public interface IMarkService
    {
        void Add(Mark entity);

        int Save();
    }
}
