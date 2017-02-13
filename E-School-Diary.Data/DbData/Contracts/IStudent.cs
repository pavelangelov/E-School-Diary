using System.Collections.Generic;

using E_School_Diary.Data.DbData.Models;

namespace E_School_Diary.Data.DbData.Contracts
{
    public interface IStudent
    {
        AspNetUser FormMaster { get; set; }

        string FormMasterId { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        ICollection<AspNetUser> Parents { get; set; }

        ICollection<Mark> Marks { get; set; }

        ICollection<Lecture> Lectures { get; set; }
    }
}
