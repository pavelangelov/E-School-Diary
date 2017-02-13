namespace E_School_Diary.Data.DbData.Models
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public DateTime SendOn { get; set; }
    }
}
