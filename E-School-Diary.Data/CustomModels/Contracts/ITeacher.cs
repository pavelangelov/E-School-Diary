using System.Collections.Generic;

using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Data.Contracts
{
    public interface ITeacher
    {
        Subject Subject { get; set; }

        string AdditionalInfo { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        ICollection<Lecture> Lectures { get; set; }
    }
}
