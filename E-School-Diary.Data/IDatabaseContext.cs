using E_School_Diary.Data.Models;
using System.Data.Entity;

namespace E_School_Diary.Data
{
    public interface IDatabaseContext
    {
        IDbSet<Lecture> Lectures { get; set; }
        IDbSet<Mark> Marks { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<StudentClass> StudentClasses { get; set; }
        IDbSet<User> Users { get; set; }

        int Save();
    }
}