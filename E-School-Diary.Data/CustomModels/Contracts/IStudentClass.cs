using System.Collections.Generic;

using E_School_Diary.Data.CustomModels.Models;

namespace E_School_Diary.Data.CustomModels.Contracts
{
    public interface IStudentClass
    {
        string Name { get; set; }

        ICollection<User> Students { get; set; }
    }
}
