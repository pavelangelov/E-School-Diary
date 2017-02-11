using System;

using E_School_Diary.Models.Contracts;
using E_School_Diary.Models.Enums;


namespace E_School_Diary.Models.Models.DataModels
{
    public class Mark : IMark, IIdentifiable
    {
        public Mark()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Mark(string studentId, Subject subject, double value)
            : this()
        {
            this.StudentId = studentId;
            this.Subject = subject;
            this.Value = value;
        }

        public string Id { get; set; }

        public AppUser Student { get; set; }

        public string StudentId { get; set; }

        public Subject Subject { get; set; }

        public double Value { get; set; }
    }
}
