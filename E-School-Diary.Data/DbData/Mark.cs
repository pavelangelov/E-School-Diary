namespace E_School_Diary.Data.DbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mark
    {
        public string Id { get; set; }

        [StringLength(128)]
        public string StudentId { get; set; }

        public int Subject { get; set; }

        public double Value { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
