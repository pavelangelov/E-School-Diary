using System.Linq;

using E_School_Diary.Data.CustomModels.Models;
using E_School_Diary.Data.CustomModels.Enums;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public class TeacherRepository : ITeacherRepository
    {
        private IDatabaseContext dbContext;

        public TeacherRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            this.dbContext.Users.Add(entity);
        }

        public IQueryable<User> GetAll()
        {
            var teachers = this.dbContext.Users.Where(x => x.UserType == UserTypes.Teacher);
            //var teachers = from role in this.dbContext.AspNetRoles
            //               from userRoles in role.AspNetUserRoles
            //               join user in dbContext.Users on userRoles.UserId equals user.Id
            //               where role.Name == "Teacher"
            //               select user;


            return teachers;
        }

        public int Save()
        {
            return dbContext.Save();
        }
    }
}
