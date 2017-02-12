namespace E_School_Diary.Data.DbData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public DateTime SendOn { get; set; }

        [StringLength(128)]
        public string AppUser_Id { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
