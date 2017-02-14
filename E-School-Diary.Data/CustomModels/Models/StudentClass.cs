using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using E_School_Diary.Data.Contracts;
using E_School_Diary.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_School_Diary.Data.Models
{
    public partial class StudentClass : IStudentClass, IIdentifiable
    {
        public StudentClass()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Students = new HashSet<User>();
            this.Lectures = new HashSet<Lecture>();
        }

        public StudentClass(string name)
            : this()
        {
            this.Name = name;
        }

        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.ClassNameMinLength, ErrorMessage = Constants.StudentClassNameErrorMessage)]
        [MaxLength(Constants.ClassNameMaxLength, ErrorMessage = Constants.StudentClassNameErrorMessage)]
        public string Name { get; set; }

        public string FormMasterId { get; set; }

        public virtual User FormMaster { get; set; }

        public virtual ICollection<User> Students { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
