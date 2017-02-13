using System;

using E_School_Diary.Data.DbData.Enums;
using E_School_Diary.Data.DbData.Models;

namespace E_School_Diary.Data.DbData.Contracts
{
    public interface ILecture
    {
        string Title { get; set; }

        AspNetUser Teacher { get; set; }

        string TeacherId { get; set; }

        StudentClass StudentClass { get; set; }

        string StudentClassId { get; set; }

        DateTime? Start { get; set; }

        DateTime? End { get; set; }

        Subject Subject { get; set; }

        LectureStatus Status { get; set; }
    }
}
