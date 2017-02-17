using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Services
{
    public class MarkService : IMarkService
    {
        IDatabaseContext dbContext;

        public MarkService(IDatabaseContext dbContext)
        {
            Validator.ValidateForNull(dbContext, "dbContext");

            this.dbContext = dbContext;
        }

        public void Add(Mark entity)
        {
            this.dbContext.Marks.Add(entity);
        }

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
