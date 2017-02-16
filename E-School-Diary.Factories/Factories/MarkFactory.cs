using E_School_Diary.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Factories
{
    public class MarkFactory : IMarkFactory
    {
        public Mark GetMark(string studentId, Subject subject, double value)
        {
            var mark = new Mark()
            {
                StudentId = studentId,
                Subject = subject,
                Value = value,
            };

            return mark;
        }
    }
}
