using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Factories.Contracts
{
    public interface IMarkFactory
    {
        Mark CreateMark(string studentId, Subject subject, double value);
    }
}
