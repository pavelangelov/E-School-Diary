namespace E_School_Diary.Data.DbData.Models
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mark
    {
        public Mark()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Mark(string studentId, Subject subject, double value)
            : this()
        {
            this.StudentId = studentId;
            this.Subject = Subject;
            this.Value = value;
        }
        public string Id { get; set; }

        [StringLength(128)]
        public string StudentId { get; set; }

        public virtual AspNetUser Student { get; set; }

        public Subject Subject { get; set; }

        public double Value { get; set; }
    }
}
