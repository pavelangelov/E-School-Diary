namespace E_School_Diary.Data.DbData.Models
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecture
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

        [StringLength(128)]
        public string StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public Subject Subject { get; set; }

        [StringLength(128)]
        public string TeacherId { get; set; }

        public virtual AspNetUser Teacher { get; set; }

        public string Title { get; set; }

    }
}
