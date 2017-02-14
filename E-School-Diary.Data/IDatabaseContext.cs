using E_School_Diary.Data.CustomModels.Models;
using System.Data.Entity;

namespace E_School_Diary.Data
{
    public interface IDatabaseContext
    {
        DbSet<Lecture> Lectures { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<StudentClass> StudentClasses { get; set; }
        DbSet<User> Users { get; set; }

        int Save();
    }
}