using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using E_School_Diary.Data.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.Models
{
    public partial class StudentClass : IStudentClass, IIdentifiable
    {
        private string name;
        private string formMasterId;

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
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                var minLength = Constants.ClassNameMinLength;
                var maxLength = Constants.ClassNameMaxLength;
                var errorMsg = Constants.StudentClassNameErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "Name", errorMsg);

                this.name = value;
            }
        }

        public string FormMasterId
        {
            get
            {
                return this.formMasterId;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                Utils.Validator.ValidateStringLength(value, Constants.IdMaxLength, Constants.IdMinLength, "FormMasterId");

                this.formMasterId = value;
            }
        }

        public virtual User FormMaster { get; set; }

        public virtual ICollection<User> Students { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
