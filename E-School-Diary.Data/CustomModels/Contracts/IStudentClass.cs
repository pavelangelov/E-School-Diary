using System.Collections.Generic;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Data.Contracts
{
    public interface IStudentClass
    {
        string Name { get; set; }

        ICollection<User> Students { get; set; }
    }
}
