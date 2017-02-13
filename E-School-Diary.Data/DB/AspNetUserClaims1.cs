namespace E_School_Diary.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserClaims1
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [StringLength(128)]
        public string AspNetUser_Id { get; set; }

        public virtual AspNetUsers1 AspNetUsers1 { get; set; }
    }
}
