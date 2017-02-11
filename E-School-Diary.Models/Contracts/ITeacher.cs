using System.Collections.Generic;

using E_School_Diary.Models.Enums;
using E_School_Diary.Models.Models.DataModels;

namespace E_School_Diary.Models.Contracts
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
