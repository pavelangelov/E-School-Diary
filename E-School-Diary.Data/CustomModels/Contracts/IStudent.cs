using System.Collections.Generic;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Data.Contracts
{
    public interface IStudent
    {
        User FormMaster { get; set; }

        string FormMasterId { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        ICollection<User> Parents { get; set; }

        ICollection<Mark> Marks { get; set; }

        ICollection<Lecture> Lectures { get; set; }
    }
}
