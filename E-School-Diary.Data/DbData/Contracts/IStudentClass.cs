using System.Collections.Generic;

using E_School_Diary.Data.DbData.Models;

namespace E_School_Diary.Data.DbData.Contracts
{
    public interface IStudentClass
    {
        string Name { get; set; }

        ICollection<AspNetUser> Students { get; set; }
    }
}
