using System;
using System.Collections.Generic;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using System.Linq;

namespace E_School_Diary.Services
{
    public class StudentClassService : IStudentClassService
    {
        private IDatabaseContext dbContext;

        public StudentClassService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<StudentClass> GetAll()
        {
            var classes = this.dbContext.StudentClasses;

            return classes;
        }

        public void Add(StudentClass entity)
        {
            this.dbContext.StudentClasses.Add(entity);
        }

        public StudentClass GetByTeacherId(string teacherId)
        {
            var studentClass = this.dbContext.StudentClasses.Single(x => x.FormMasterId == teacherId);

            return studentClass;
        }

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
