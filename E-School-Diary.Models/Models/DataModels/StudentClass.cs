using System;
using System.Collections.Generic;

using E_School_Diary.Models.Contracts;

namespace E_School_Diary.Models.Models.DataModels
{
    public class StudentClass : IStudentClass, IIdentifiable
    {
        private ICollection<AppUser> students;

        public StudentClass()
        {
            this.Id = Guid.NewGuid().ToString();
            this.students = new HashSet<AppUser>();
        }

        public StudentClass(string name)
            : this()
        {
            this.Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AppUser> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }
    }
}
