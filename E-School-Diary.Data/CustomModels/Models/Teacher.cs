using E_School_Diary.Data.CustomModels.Contracts;
using E_School_Diary.Data.CustomModels.Enums;
using E_School_Diary.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data.CustomModels.Models
{
    public class Teacher : User, ITeacher
    {
        public Teacher()
            : base(UserTypes.Teacher)
        {
            this.Lectures = new HashSet<Lecture>();
        }

        public Teacher(string userName, Subject subject)
            : this()
        {
            this.UserName = userName;
            this.Subject = subject;
        }

        public string StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public Subject Subject { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        [MaxLength(Constants.AdditionalInfoMaxLength, ErrorMessage = Constants.AdditionalInfoErrorMessage)]
        public string AdditionalInfo { get; set; }
    }
}
