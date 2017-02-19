using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Factories.Contracts;

namespace E_School_Diary.Factories
{
    public class MarkFactory : IMarkFactory
    {
        public Mark CreateMark(string studentId, Subject subject, double value)
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
