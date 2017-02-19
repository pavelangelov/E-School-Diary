using System;
using System.ComponentModel.DataAnnotations;

using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.Models
{
    public partial class Lecture : ILecture, IIdentifiable
    {
        private string title;
        private string teacherId;
        private string classId;

        public Lecture()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Status = LectureStatus.Ahead;
        }

        public Lecture(string teacherId, string classId, string title, DateTime start, DateTime end, Subject subject)
            : this()
        {
            this.TeacherId = teacherId;
            this.StudentClassId = classId;
            this.Title = title;
            this.Start = start;
            this.End = end;
            this.Subject = subject;
        }

        [StringLength(128)]
        public string Id { get; set; }

        public DateTime? End { get; set; }

        public DateTime? Start { get; set; }

        public LectureStatus Status { get; set; }

        [StringLength(128)]
        public string StudentClassId
        {
            get
            {
                return this.classId;
            }

            set
            {
                Utils.Validator.ValidateStringLength(value, Constants.IdMaxLength, Constants.IdMinLength, "ClassId");

                this.classId = value;
            }
        }

        public virtual StudentClass StudentClass { get; set; }

        public Subject Subject { get; set; }

        [StringLength(128)]
        public string TeacherId
        {
            get
            {
                return this.teacherId;
            }

            set
            {
                Utils.Validator.ValidateStringLength(value, Constants.IdMaxLength, Constants.IdMinLength, "TeacherId");

                this.teacherId = value;
            }
        }

        public virtual User Teacher { get; set; }

        [Required]
        [MinLength(Constants.LectureTitleMinLength, ErrorMessage = Constants.LectureTitleErrorMessage)]
        [MaxLength(Constants.LectureTitleMaxLength, ErrorMessage = Constants.LectureTitleErrorMessage)]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                var minLength = Constants.LectureTitleMinLength;
                var maxLength = Constants.LectureTitleMaxLength;
                var errorMsg = Constants.LectureTitleErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "Title", errorMsg);

                this.title = value;
            }
        }

    }
}
