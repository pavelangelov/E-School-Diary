using E_School_Diary.Data.DbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface IStudentRepository
    {
        IQueryable<IGrouping<int, Mark>> GetStudentMarks(string studentId);
    }
}
