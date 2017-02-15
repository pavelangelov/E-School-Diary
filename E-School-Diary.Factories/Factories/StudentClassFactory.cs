using System;

using E_School_Diary.Data.Models;
using E_School_Diary.Factories.Contracts;

namespace E_School_Diary.Factories
{
    public class StudentClassFactory : IStudentClassFactory
    {
        public StudentClass CreateClass(string className, string teacherId)
        {
            var stClass = new StudentClass()
            {
                Id = Guid.NewGuid().ToString(),
                Name = className,
                FormMasterId = teacherId
            };

            return stClass;
        }
    }
}
