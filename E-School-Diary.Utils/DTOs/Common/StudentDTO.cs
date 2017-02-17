using System;

namespace E_School_Diary.Utils.DTOs.Common
{
    public class StudentDTO : IComparable<StudentDTO>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string MarkValue { get; set; }

        public int CompareTo(StudentDTO other)
        {
            if (this.FirstName.CompareTo(other.FirstName) == 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            return this.FirstName.CompareTo(other.FirstName);
        }
    }
}
