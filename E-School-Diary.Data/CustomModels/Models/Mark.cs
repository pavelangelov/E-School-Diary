using System;
using System.ComponentModel.DataAnnotations;

using E_School_Diary.Data.Contracts;
using E_School_Diary.Data.Enums;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.Models
{
    public partial class Mark : IMark, IIdentifiable
    {
        private double markValue;

        public Mark()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Mark(string studentId, Subject subject, double value)
            : this()
        {
            this.StudentId = studentId;
            this.Subject = Subject;
            this.Value = value;
        }

        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string StudentId { get; set; }

        public virtual User Student { get; set; }

        public Subject Subject { get; set; }

        [Required]
        [Range(Constants.MarkMinValue, Constants.MarkMaxValue, ErrorMessage = Constants.MarkValueErrorMessage)]
        public double Value
        {
            get
            {
                return this.markValue;
            }

            set
            {
                var minValue = Constants.MarkMinValue;
                var maxValue = Constants.MarkMaxValue;
                var errorMsg = Constants.MarkValueErrorMessage;

                Utils.Validator.ValidateDoubleValue(value, maxValue, minValue, "Value", errorMsg);

                this.markValue = value;
            }
        }
    }
}
