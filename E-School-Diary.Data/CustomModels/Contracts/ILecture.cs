using System;

using E_School_Diary.Data.CustomModels.Enums;
using E_School_Diary.Data.CustomModels.Models;

namespace E_School_Diary.Data.CustomModels.Contracts
{
    public interface ILecture
    {
        string Title { get; set; }

        User Teacher { get; set; }

        string TeacherId { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        DateTime? Start { get; set; }

        DateTime? End { get; set; }

        Subject Subject { get; set; }

        LectureStatus Status { get; set; }
    }
}
