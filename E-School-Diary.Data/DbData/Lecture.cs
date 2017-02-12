namespace E_School_Diary.Data.DbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecture
    {
        public string Id { get; set; }

        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public int Status { get; set; }

        [StringLength(128)]
        public string StudentClassId { get; set; }

        public int Subject { get; set; }

        [StringLength(128)]
        public string TeacherId { get; set; }

        public string Title { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual StudentClass StudentClass { get; set; }
    }
}
