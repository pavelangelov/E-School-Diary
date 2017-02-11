using System.Collections.Generic;

using E_School_Diary.Models.Models;

namespace E_School_Diary.Models.Contracts
{
    public interface IStudentClass
    {
        string Name { get; set; }

        ICollection<AppUser> Students { get; set; }
    }
}
