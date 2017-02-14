using E_School_Diary.Data.CustomModels.Contracts;
using E_School_Diary.Data.CustomModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data.CustomModels.Models
{
    public class Student : User, IStudent
    {
        public Student()
            : base(UserTypes.Student)
        {
            this.Parents = new HashSet<Parent>();
            this.Marks = new HashSet<Mark>();
        }

        public Student(string userName)
            : this()
        {
            this.UserName = userName;
        }

        [StringLength(128)]
        public string FormMasterId { get; set; }

        public virtual Teacher FormMaster { get; set; }

        [StringLength(128)]
        public string StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
