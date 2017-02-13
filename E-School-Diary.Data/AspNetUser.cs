namespace E_School_Diary.Data
{
    using DbData.Enums;
    using DbData.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUser : IdentityUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUser()
        {
            this.Id = Guid.NewGuid().ToString();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetRoles = new HashSet<AspNetRole>();

            Parents = new HashSet<AspNetUser>();
            Lectures = new HashSet<Lecture>();
            Marks = new HashSet<Mark>();
            Messages = new HashSet<Message>();
        }

        public AspNetUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public string AdditionalInfo { get; set; }

        public int Age { get; set; }

        [StringLength(128)]
        public string ChildId { get; set; }

        public virtual AspNetUser Child { get; set; }

        public string ConfirmIdentity { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(128)]
        public string FormMasterId { get; set; }

        public virtual AspNetUser FormMaster { get; set; }

        [StringLength(128)]
        public string StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public Subject Subject { get; set; }

        public virtual ICollection<AspNetUser> Parents { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
