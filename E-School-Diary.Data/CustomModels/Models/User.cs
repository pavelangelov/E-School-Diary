using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity.EntityFramework;

using E_School_Diary.Data.Enums;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public User(string userName)
            : this()
        {
            this.UserName = userName;
        }
        
        [MaxLength(Constants.AdditionalInfoMaxLength, ErrorMessage = Constants.AdditionalInfoErrorMessage)]
        public string AdditionalInfo { get; set; }

        [Required]
        [Range(Constants.StudentAgeMinValue, Constants.AgeMaxValue)]
        public int Age { get; set; }
        
        public string ChildId { get; set; }

        public virtual User Child { get; set; }

        public string ConfirmIdentity { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.NameErrorMessage)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.NameErrorMessage)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.NameErrorMessage)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.NameErrorMessage)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public UserTypes UserType { get; set; }

        public string FormMasterId { get; set; }

        public virtual User FormMaster { get; set; }
        
        public string StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public Subject Subject { get; set; }

        public virtual ICollection<User> Parents { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }

    }
}
