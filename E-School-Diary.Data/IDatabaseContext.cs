using System.Data.Entity;

namespace E_School_Diary.Data.DB.Contracts
{
    public interface IDatabaseContext
    {
        int Save();
    }
}