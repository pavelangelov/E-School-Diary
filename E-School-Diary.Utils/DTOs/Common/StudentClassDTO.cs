using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Utils.DTOs.Common
{
    public class StudentClassDTO : IComparable<StudentClassDTO>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int CompareTo(StudentClassDTO other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
