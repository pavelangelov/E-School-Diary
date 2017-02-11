﻿using System;

using E_School_Diary.Models.Contracts;
using E_School_Diary.Models.Enums;

namespace E_School_Diary.Models.Models.DataModels
{
    public class Lecture : ILecture, IIdentifiable
    {
        public Lecture()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Status = LectureStatus.Ahead;
        }

        public Lecture(string teacherId, string classId, string title, DateTime start, DateTime end, Subject subject)
            : this()
        {
            this.TeacherId = teacherId;
            this.StudentClassId = classId;
            this.Title = title;
            this.Start = start;
            this.End = end;
            this.Subject = subject;
        }

        public string Id { get; set; }

        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public LectureStatus Status { get; set; }

        public string StudentClassId { get; set; }

        public StudentClass StudentsClass { get; set; }

        public Subject Subject { get; set; }

        public AppUser Teacher { get; set; }

        public string TeacherId { get; set; }

        public string Title { get; set; }
    }
}
