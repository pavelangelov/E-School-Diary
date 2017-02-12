using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_School_Diary.Data.DbData;
using System.Data.Entity;
using E_School_Diary.Data.Repositories.Contracts;

namespace E_School_Diary.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IDatabaseContext dbContext;

        public StudentRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<IGrouping<int, Mark>> GetStudentMarks(string studentId)
        {
            var studentMarks = this.dbContext.Marks.Where(m => m.StudentId == studentId)
                                                    .GroupBy(m => m.Subject);

            return studentMarks;
        }
    }
}
