using E_School_Diary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_School_Diary.Data.Models;
using E_School_Diary.Data;

namespace E_School_Diary.Services
{
    public class MarkService : IMarkService
    {
        IDatabaseContext dbContext;

        public MarkService(IDatabaseContext dbContext)
        {
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
