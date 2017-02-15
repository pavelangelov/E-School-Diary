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
        private int age;
        private string firstName;
        private string middleName;
        private string lastName;
        private string additionalInfo;

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
        public string AdditionalInfo
        {
            get
            {
                return this.additionalInfo;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                var minLength = 0;
                var maxLength = Constants.AdditionalInfoMaxLength;
                var errorMsg = Constants.AdditionalInfoErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "AdditionalInfo", errorMsg);

                this.additionalInfo = value;
            }
        }

        [Required]
        [Range(Constants.StudentAgeMinValue, Constants.AgeMaxValue)]
        public int Age { get; set; }
        
        public string ChildId { get; set; }

        public virtual User Child { get; set; }

        public string ConfirmIdentity { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.NameErrorMessage)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.NameErrorMessage)]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                var minLength = Constants.NameMinLength;
                var maxLength = Constants.NameMaxLength;
                var errorMsg = Constants.NameErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "FirstName", errorMsg);

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                var minLength = Constants.NameMinLength;
                var maxLength = Constants.NameMaxLength;
                var errorMsg = Constants.NameErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "MiddleName", errorMsg);

                this.firstName = value;
            }
        }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.NameErrorMessage)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.NameErrorMessage)]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                var minLength = Constants.NameMinLength;
                var maxLength = Constants.NameMaxLength;
                var errorMsg = Constants.NameErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "LastName", errorMsg);

                this.firstName = value;
            }
        }

        public string ImageUrl { get; set; }

        public bool IsFreeTeacher { get; set; }

        public UserTypes UserType { get; set; }
        
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
