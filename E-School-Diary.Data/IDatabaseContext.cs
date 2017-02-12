using E_School_Diary.Data.DbData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data
{
    public interface IDatabaseContext
    {
        IDbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        IDbSet<AppUser> AppUsers { get; set; }
        IDbSet<AspNetRole> AspNetRoles { get; set; }
        IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        IDbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        IDbSet<AspNetUser> AspNetUsers { get; set; }
        IDbSet<Lecture> Lectures { get; set; }
        IDbSet<Mark> Marks { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<StudentClass> StudentClasses { get; set; }

        int Save();
    }
}
