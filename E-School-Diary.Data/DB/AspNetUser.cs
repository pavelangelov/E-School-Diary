namespace E_School_Diary.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUser
    {
        public string Id { get; set; }

        public virtual AspNetUsers1 AspNetUsers1 { get; set; }
    }
}
