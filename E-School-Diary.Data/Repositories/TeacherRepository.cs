using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_School_Diary.Data.DbData;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public class TeacherRepository : ITeacherRepository
    {
        private IDatabaseContext dbContext;

        public TeacherRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(AppUser entity)
        {
            this.dbContext.AppUsers.Add(entity);
        }

        public IQueryable<AppUser> GetAll()
        {
            //var teachers = this.dbContext.AppUsers
            //                                .Where(x => x.AspNetUserRoles.Any(r => r.RoleId == "2"));
            var teachers = from role in this.dbContext.AspNetRoles
                           from userRoles in role.AspNetUserRoles
                           join user in dbContext.AppUsers on userRoles.UserId equals user.Id
                           where role.Name == "Teacher"
                           select user;
                                 

            return teachers;
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
