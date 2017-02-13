using System;

using E_School_Diary.Data.DB.Contracts;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public class TeacherRepository : ITeacherRepository
    {
        private IDatabaseContext dbContext;

        public TeacherRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public void Add(AspNetUsers1 entity)
        //{
        //    this.dbContext.AspNetUsers1.Add(entity);
        //}

        //public IQueryable<AspNetUsers1> GetAll()
        //{
        //    //var teachers = this.dbContext.AppUsers
        //    //                                .Where(x => x.AspNetUserRoles.Any(r => r.RoleId == "2"));
        //    var teachers = from role in this.dbContext.AspNetRoles
        //                   from userRoles in role.AspNetUserRoles
        //                   join user in dbContext.AspNetUsers1 on userRoles.UserId equals user.Id
        //                   where role.Name == "Teacher"
        //                   select user;
                                 

        //    return teachers;
        //}

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
