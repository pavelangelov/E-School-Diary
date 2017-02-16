using System;
using System.Collections.Generic;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using System.Linq;
using System.Data.Entity;

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

        public StudentClass FindByTeacherId(string teacherId)
        {
            var studentClass = this.dbContext.StudentClasses.Single(x => x.FormMasterId == teacherId);

            return studentClass;
        }

        public int Save()
        {
            return this.dbContext.Save();
        }

        public StudentClass FindById(string studentClassId)
        {
            var studentClass = this.dbContext.StudentClasses
                                                .Include(st => st.Lectures)
                                                .Include(st=> st.Students)
                                                .First(st => st.Id == studentClassId);
            return studentClass;
        }
    }
}
