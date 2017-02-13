using E_School_Diary.Data.EF_DataSource;
using System.Data.Entity;

namespace E_School_Diary.Data
{
    public interface IDatabaseContext
    {
        DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<Lecture> Lectures { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<StudentClass> StudentClasses { get; set; }
        DbSet<User> Users { get; set; }

        int Save();
    }
}