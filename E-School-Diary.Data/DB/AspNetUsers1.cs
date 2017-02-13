namespace E_School_Diary.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUsers1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUsers1()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserClaims1 = new HashSet<AspNetUserClaims1>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserLogins1 = new HashSet<AspNetUserLogins1>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUsers11 = new HashSet<AspNetUsers1>();
            AspNetUsers111 = new HashSet<AspNetUsers1>();
            AspNetUsers112 = new HashSet<AspNetUsers1>();
            Lectures = new HashSet<Lecture>();
            Marks = new HashSet<Mark>();
            Messages = new HashSet<Message>();
            AspNetRoles1 = new HashSet<AspNetRoles1>();
        }

        public string Id { get; set; }

        public string AdditionalInfo { get; set; }

        public int Age { get; set; }

        [StringLength(128)]
        public string ChildId { get; set; }

        public string ConfirmIdentity { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(128)]
        public string FormMasterId { get; set; }

        [StringLength(128)]
        public string StudentClassId { get; set; }

        public int Subject { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(128)]
        public string AspNetUser_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserClaims1> AspNetUserClaims1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserLogins1> AspNetUserLogins1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUsers1> AspNetUsers11 { get; set; }

        public virtual AspNetUsers1 AspNetUsers12 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUsers1> AspNetUsers111 { get; set; }

        public virtual AspNetUsers1 AspNetUsers13 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUsers1> AspNetUsers112 { get; set; }

        public virtual AspNetUsers1 AspNetUsers14 { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lecture> Lectures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mark> Marks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRoles1> AspNetRoles1 { get; set; }
    }
}
