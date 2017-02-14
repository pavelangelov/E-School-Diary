using System.Collections.Generic;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;

namespace E_School_Diary.Services
{
    public class TeacherService : ITeacherService
    {
        private IDatabaseContext dbContext;

        public TeacherService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            this.dbContext.Users.Add(entity);
        }

        public IEnumerable<User> GetAll()
        {
            var teachers = this.dbContext.Users.Where(x => x.UserType == UserTypes.Teacher);

            return teachers;
        }

        public int Save()
        {
            return dbContext.Save();
        }
    }
}
