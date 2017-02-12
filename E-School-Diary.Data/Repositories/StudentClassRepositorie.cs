using E_School_Diary.Data.DbData;
using E_School_Diary.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data.Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private IDatabaseContext dbContext;

        public StudentClassRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<StudentClass> GetAll()
        {
            var classes = this.dbContext.StudentClasses;

            return classes;
        }

        public void Add(StudentClass entity)
        {
            this.dbContext.StudentClasses.Add(entity);
        }

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
