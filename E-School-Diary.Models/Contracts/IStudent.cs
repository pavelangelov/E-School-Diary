using System.Collections.Generic;

using E_School_Diary.Models.Models;
using E_School_Diary.Models.Models.DataModels;

namespace E_School_Diary.Models.Contracts
{
    public interface IStudent
    {
        AppUser FormMaster { get; set; }

        string FormMasterId { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        ICollection<AppUser> Parents { get; set; }

        ICollection<Mark> Marks { get; set; }

        ICollection<Lecture> Lectures { get; set; }
    }
}
