using System;

using E_School_Diary.Models.Enums;
using E_School_Diary.Models.Models.DataModels;
using E_School_Diary.Models.Models;

namespace E_School_Diary.Models.Contracts
{
    public interface ILecture
    {
        string Title { get; set; }

        AppUser Teacher { get; set; }

        string TeacherId { get; set; }

        StudentClass StudentsClass { get; set; }

        string StudentClassId { get; set; }

        DateTime? Start { get; set; }

        DateTime? End { get; set; }

        Subject Subject { get; set; }

        LectureStatus Status { get; set; }
    }
}
